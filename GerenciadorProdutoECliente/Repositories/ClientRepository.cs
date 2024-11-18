using System;
using System.Collections.Generic;
using System.Linq;
using GerenciadorProdutoECliente.Enums;
using GerenciadorProdutoECliente.Models;
using Npgsql;
using GerenciadorProdutoECliente.Data;

namespace GerenciadorProdutoECliente.Repositories
{
    // Classe responsável por realizar as operações de CRUD (Create, Read, Update, Delete) para o cliente no banco de dados
    public class ClientRepository
    {

        // Método para adicionar um novo cliente no banco
        public bool AddClient(Client client)
        {
            // Validação do CPF ou CNPJ
            client.ValidateCpfOrCnpj();

            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
            INSERT INTO clientes (nome, cpf, cnpj, telefone, email, tipo_cliente) 
            VALUES (@Name, @Cpf, @Cnpj, @Phone, @Email, @ClientType) 
            RETURNING id;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    // Parâmetros principais do cliente
                    command.Parameters.AddWithValue("@Name", client.Name);
                    command.Parameters.AddWithValue("@Cpf", client.Cpf ?? (object)DBNull.Value); // Se for nulo, passa DBNull
                    command.Parameters.AddWithValue("@Cnpj", client.Cnpj ?? (object)DBNull.Value); // Se for nulo, passa DBNull
                    command.Parameters.AddWithValue("@Phone", client.Phone);
                    command.Parameters.AddWithValue("@Email", client.Email);
                    command.Parameters.AddWithValue("@ClientType", client.ClientType.ToString());

                    // Obtém o ID gerado pelo banco após o INSERT
                    client.Id = (int)command.ExecuteScalar();
                    string addressQuery = @"
                    INSERT INTO enderecos (cep, rua, numero, complemento, bairro, cidade, uf, cliente_id) 
                    VALUES (@ZipCode, @Street, @Number, @Complement, @Neighborhood, @City, @State, @ClientId);";

                     using (NpgsqlCommand addressCommand = new NpgsqlCommand(addressQuery, connection))
                     {
                            addressCommand.Parameters.AddWithValue("@ZipCode", client.Address.ZipCode);
                            addressCommand.Parameters.AddWithValue("@Street", client.Address.Street);
                            addressCommand.Parameters.AddWithValue("@Number", client.Address.Number);
                            addressCommand.Parameters.AddWithValue("@Complement", client.Address.Complement ?? (object)DBNull.Value);
                            addressCommand.Parameters.AddWithValue("@Neighborhood", client.Address.Neighborhood);
                            addressCommand.Parameters.AddWithValue("@City", client.Address.City);
                            addressCommand.Parameters.AddWithValue("@State", client.Address.State);
                            addressCommand.Parameters.AddWithValue("@ClientId", client.Id);
                            addressCommand.ExecuteNonQuery();
                     }

                    return true;
                }
            }
        }


        // Método para atualizar um cliente existente no banco de dados
        public bool UpdateClient(Client client)
        {
            // Validação do CPF ou CNPJ
            client.ValidateCpfOrCnpj();

            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
            UPDATE clientes
            SET nome = @Name, cpf = @Cpf, cnpj = @Cnpj, telefone = @Phone, email = @Email, tipo_cliente = @ClientType
            WHERE id = @Id;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    // Parâmetros principais do cliente
                    command.Parameters.AddWithValue("@Id", client.Id);
                    command.Parameters.AddWithValue("@Name", client.Name);
                    command.Parameters.AddWithValue("@Cpf", client.Cpf ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Cnpj", client.Cnpj ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Phone", client.Phone);
                    command.Parameters.AddWithValue("@Email", client.Email);
                    command.Parameters.AddWithValue("@ClientType", client.ClientType.ToString());

                    command.ExecuteNonQuery();
                }

                // Atualizar Endereço - Deletar o antigo e adicionar o novo
                string deleteAddressesQuery = "DELETE FROM enderecos WHERE cliente_id = @ClientId";
                using (NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteAddressesQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@ClientId", client.Id);
                    deleteCommand.ExecuteNonQuery();
                }
                string addressQuery = @"
                INSERT INTO enderecos (cep, rua, numero, complemento, bairro, cidade, uf, cliente_id) 
                VALUES (@ZipCode, @Street, @Number, @Complement, @Neighborhood, @City, @State, @ClientId);";

                using (NpgsqlCommand addressCommand = new NpgsqlCommand(addressQuery, connection))
                {
                        addressCommand.Parameters.AddWithValue("@ZipCode", client.Address.ZipCode);
                        addressCommand.Parameters.AddWithValue("@Street", client.Address.Street);
                        addressCommand.Parameters.AddWithValue("@Number", client.Address.Number);
                        addressCommand.Parameters.AddWithValue("@Complement", client.Address.Complement ?? (object)DBNull.Value);
                        addressCommand.Parameters.AddWithValue("@Neighborhood", client.Address.Neighborhood);
                        addressCommand.Parameters.AddWithValue("@City", client.Address.City);
                        addressCommand.Parameters.AddWithValue("@State", client.Address.State);
                        addressCommand.Parameters.AddWithValue("@ClientId", client.Id);
                        addressCommand.ExecuteNonQuery();
                }

                return true;
            }
        }


        // Método para deletar um cliente do banco de dados
        public bool DeleteClient(int clientId)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                NpgsqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Excluir Endereço
                    string deleteAddressesQuery = "DELETE FROM enderecos WHERE cliente_id = @ClientId";
                    using (NpgsqlCommand deleteAddressCommand = new NpgsqlCommand(deleteAddressesQuery, connection, transaction))
                    {
                        deleteAddressCommand.Parameters.AddWithValue("@ClientId", clientId);
                        deleteAddressCommand.ExecuteNonQuery();
                    }

                    // Excluir Cliente
                    string deleteClientQuery = "DELETE FROM clientes WHERE id = @ClientId";
                    using (NpgsqlCommand deleteClientCommand = new NpgsqlCommand(deleteClientQuery, connection, transaction))
                    {
                        deleteClientCommand.Parameters.AddWithValue("@ClientId", clientId);
                        deleteClientCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private Client SearchByCpf(string cpf)
        {
            // Remove a formatação do CPF para garantir que a busca seja feita apenas com os números
            string cleanedCpf = new string(cpf.Where(char.IsDigit).ToArray());

            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
SELECT id, nome, cpf, cnpj, telefone, email, client_type
FROM clientes
WHERE REPLACE(REPLACE(REPLACE(cpf, '.', ''), '/', ''), '-', '') = @Cpf";  // Busca pelo CPF sem formatação

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cpf", cleanedCpf);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())  // Se encontrar o cliente
                        {
                            Client client = new Client
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Cpf = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Cnpj = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                                ClientType = (ClientType)reader.GetChar(6)  // Convertendo tipo_cliente de char para enum
                            };

                            // Busca o endereço associado ao cliente.
                            string addressQuery = "SELECT * FROM enderecos WHERE cliente_id = @ClientId LIMIT 1"; // Limitado a um único endereço
                            using (NpgsqlCommand addressCommand = new NpgsqlCommand(addressQuery, connection))
                            {
                                addressCommand.Parameters.AddWithValue("@ClientId", client.Id);

                                using (NpgsqlDataReader addressReader = addressCommand.ExecuteReader())
                                {
                                    if (addressReader.Read())  // Se encontrar o endereço
                                    {
                                        // Atribui o primeiro endereço encontrado ao cliente
                                        client.Address = new Address
                                        {
                                            Id = addressReader.GetInt32(addressReader.GetOrdinal("id")),
                                            ZipCode = addressReader.GetString(addressReader.GetOrdinal("cep")),
                                            Street = addressReader.GetString(addressReader.GetOrdinal("rua")),
                                            Number = addressReader.GetString(addressReader.GetOrdinal("numero")),
                                            Complement = addressReader.IsDBNull(addressReader.GetOrdinal("complemento")) ? null : addressReader.GetString(addressReader.GetOrdinal("complemento")),
                                            Neighborhood = addressReader.GetString(addressReader.GetOrdinal("bairro")),
                                            City = addressReader.GetString(addressReader.GetOrdinal("cidade")),
                                            State = addressReader.GetString(addressReader.GetOrdinal("uf")),
                                            ClientId = client.Id
                                        };
                                    }
                                }
                            }

                            return client;  // Retorna o cliente com o endereço associado
                        }
                    }
                }
            }

            return null;  // Retorna null se o CPF não for encontrado
        }


        private Client SearchByCnpj(string cnpj)
        {
            // Remove a formatação do CNPJ para garantir que a busca seja feita apenas com os números
            string cleanedCnpj = new string(cnpj.Where(char.IsDigit).ToArray());
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
        SELECT id, nome, cpf, cnpj, telefone, email, tipo_cliente
        FROM clientes
        WHERE REPLACE(REPLACE(REPLACE(cnpj, '.', ''), '/', ''), '-', '') = @Cnpj";  // Busca pelo CNPJ sem formatação

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cnpj", cleanedCnpj);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())  // Se encontrar o cliente
                        {
                            Client client = new Client
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Cpf = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Cnpj = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                                ClientType = (ClientType)reader.GetChar(6)  // Convertendo tipo_cliente de char para enum
                            };

                            // Busca o endereço associado ao cliente.
                            string addressQuery = "SELECT * FROM enderecos WHERE cliente_id = @ClientId LIMIT 1"; // Limitado a um único endereço
                            using (NpgsqlCommand addressCommand = new NpgsqlCommand(addressQuery, connection))
                            {
                                addressCommand.Parameters.AddWithValue("@ClientId", client.Id);

                                using (NpgsqlDataReader addressReader = addressCommand.ExecuteReader())
                                {
                                    if (addressReader.Read())  // Se encontrar o endereço
                                    {
                                        // Atribui o primeiro endereço encontrado ao cliente
                                        client.Address = new Address
                                        {
                                            Id = addressReader.GetInt32(addressReader.GetOrdinal("id")),
                                            ZipCode = addressReader.GetString(addressReader.GetOrdinal("cep")),
                                            Street = addressReader.GetString(addressReader.GetOrdinal("rua")),
                                            Number = addressReader.GetString(addressReader.GetOrdinal("numero")),
                                            Complement = addressReader.IsDBNull(addressReader.GetOrdinal("complemento")) ? null : addressReader.GetString(addressReader.GetOrdinal("complemento")),
                                            Neighborhood = addressReader.GetString(addressReader.GetOrdinal("bairro")),
                                            City = addressReader.GetString(addressReader.GetOrdinal("cidade")),
                                            State = addressReader.GetString(addressReader.GetOrdinal("uf")),
                                            ClientId = client.Id
                                        };
                                    }
                                }
                            }

                            return client;
                        }
                    }
                }
            }
            return null;  // Retorna null se o CNPJ não for encontrado
        }

        private Client SearchByName(string name)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
        SELECT id, nome, cpf, cnpj, telefone, email, tipo_cliente
        FROM clientes
        WHERE nome ILIKE @Name";  // ILIKE faz uma busca insensível a maiúsculas/minúsculas

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", "%" + name + "%");  // Busca por nome parcial

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())  // Se encontrar o cliente
                        {
                            Client client = new Client
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Cpf = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Cnpj = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Email = reader.IsDBNull(5) ? null : reader.GetString(5),
                                ClientType = (ClientType)reader.GetChar(6)  // Convertendo tipo_cliente de char para enum
                            };

                            // Busca o endereço associado ao cliente.
                            string addressQuery = "SELECT * FROM enderecos WHERE cliente_id = @ClientId LIMIT 1"; // Limitado a um único endereço
                            using (NpgsqlCommand addressCommand = new NpgsqlCommand(addressQuery, connection))
                            {
                                addressCommand.Parameters.AddWithValue("@ClientId", client.Id);

                                using (NpgsqlDataReader addressReader = addressCommand.ExecuteReader())
                                {
                                    if (addressReader.Read())  // Se encontrar o endereço
                                    {
                                        // Atribui o primeiro endereço encontrado ao cliente
                                        client.Address = new Address
                                        {
                                            Id = addressReader.GetInt32(addressReader.GetOrdinal("id")),
                                            ZipCode = addressReader.GetString(addressReader.GetOrdinal("cep")),
                                            Street = addressReader.GetString(addressReader.GetOrdinal("rua")),
                                            Number = addressReader.GetString(addressReader.GetOrdinal("numero")),
                                            Complement = addressReader.IsDBNull(addressReader.GetOrdinal("complemento")) ? null : addressReader.GetString(addressReader.GetOrdinal("complemento")),
                                            Neighborhood = addressReader.GetString(addressReader.GetOrdinal("bairro")),
                                            City = addressReader.GetString(addressReader.GetOrdinal("cidade")),
                                            State = addressReader.GetString(addressReader.GetOrdinal("uf")),
                                            ClientId = client.Id
                                        };
                                    }
                                }
                            }

                            return client;
                        }
                    }
                }
            }
            return null;  // Retorna null se o nome não for encontrado
        }

        public Client SearchByIdentifier(string identifier)
        {
            // Remover espaços em branco antes e depois da string
            identifier = identifier.Trim();

            // Verifica se a string está vazia
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentException("O identificador não pode ser vazio.");
            }
            // Tenta verificar se o identificador é numérico e se pode ser um CPF ou CNPJ
            if (long.TryParse(identifier, out long result))
            {
                // Verifica se é CPF ou CNPJ
                if (identifier.Length == 11)
                {
                    // Caso tenha 11 dígitos, é CPF
                    return SearchByCpf(identifier);
                }
                else if (identifier.Length == 14)
                {
                    // Caso tenha 14 dígitos, é CNPJ
                    return SearchByCnpj(identifier);
                }
                else
                {
                    // Se não tiver 11 ou 14 dígitos, lança um erro
                    throw new ArgumentException("O CPF ou CNPJ deve ter 11 ou 14 dígitos.");
                }
            }
            else
            {
                // Se não for numérico, trata como nome
                return SearchByName(identifier);
            }
        }
    }
}