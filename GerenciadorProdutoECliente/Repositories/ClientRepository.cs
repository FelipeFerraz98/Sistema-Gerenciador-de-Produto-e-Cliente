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
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
            INSERT INTO clientes (nome, cpf, cnpj, telefone, email, tipo_cliente) 
            VALUES (@Name, @Cpf, @Cnpj, @Phone, @Email, @ClientType) 
            RETURNING id;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    char clientTypeChar = client.ClientType == ClientType.Individual ? 'I' : 'J';

                    // Parâmetros principais do cliente
                    command.Parameters.AddWithValue("@Name", client.Name);
                    command.Parameters.AddWithValue("@Cpf", client.Cpf ?? (object)DBNull.Value); // Se for nulo, passa DBNull
                    command.Parameters.AddWithValue("@Cnpj", client.Cnpj ?? (object)DBNull.Value); // Se for nulo, passa DBNull
                    command.Parameters.AddWithValue("@Phone", client.Phone);
                    command.Parameters.AddWithValue("@Email", client.Email);
                    command.Parameters.AddWithValue("@ClientType", clientTypeChar);

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
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
            UPDATE clientes
            SET nome = @Name, telefone = @Phone, email = @Email
            WHERE id = @Id;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    // Parâmetros principais do cliente
                    command.Parameters.AddWithValue("@Id", client.Id);
                    command.Parameters.AddWithValue("@Name", client.Name);
                    command.Parameters.AddWithValue("@Phone", client.Phone);
                    command.Parameters.AddWithValue("@Email", client.Email);

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

        //Método para buscar um endereco de um cliente
        private Address SearchAddressByClientId(int clientId, NpgsqlConnection connection)
        {
            string addressQuery = "SELECT * FROM enderecos WHERE cliente_id = @ClientId LIMIT 1"; // Limitado a um único endereço

            using (NpgsqlCommand addressCommand = new NpgsqlCommand(addressQuery, connection))
            {
                addressCommand.Parameters.AddWithValue("@ClientId", clientId);

                using (NpgsqlDataReader addressReader = addressCommand.ExecuteReader())
                {
                    if (addressReader.Read())  // Se encontrar o endereço
                    {
                        // Retorna o endereço encontrado
                        return new Address
                        {
                            Id = addressReader.GetInt32(addressReader.GetOrdinal("id")),
                            ZipCode = addressReader.GetString(addressReader.GetOrdinal("cep")),
                            Street = addressReader.GetString(addressReader.GetOrdinal("rua")),
                            Number = addressReader.GetString(addressReader.GetOrdinal("numero")),
                            Complement = addressReader.IsDBNull(addressReader.GetOrdinal("complemento")) ? null : addressReader.GetString(addressReader.GetOrdinal("complemento")),
                            Neighborhood = addressReader.GetString(addressReader.GetOrdinal("bairro")),
                            City = addressReader.GetString(addressReader.GetOrdinal("cidade")),
                            State = addressReader.GetString(addressReader.GetOrdinal("uf")),
                            ClientId = clientId
                        };
                    }
                }
            }

            return null;  // Retorna null caso o endereço não seja encontrado
        }

        //Método para buscar um cliente por CPF
        private List<Client> SearchByCpf(string cpf)
        {
            // Remove a formatação do CPF para garantir que a busca seja feita apenas com os números
            string cleanedCpf = new string(cpf.Where(char.IsDigit).ToArray());
            var clients = new List<Client>();  // Lista para armazenar os clientes encontrados

            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
SELECT id, nome, cpf, cnpj, telefone, email, tipo_cliente
FROM clientes
WHERE REPLACE(REPLACE(REPLACE(cpf, '.', ''), '/', ''), '-', '') = @Cpf";  // Busca pelo CPF sem formatação

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cpf", cleanedCpf);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())  // While para percorrer todos os resultados
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

                            // Busca o endereço associado ao cliente em uma nova conexão
                            using (NpgsqlConnection addressConnection = DBConnection.OpenConnection())
                            {
                                client.Address = SearchAddressByClientId(client.Id, addressConnection);
                            }

                            clients.Add(client);  // Adiciona o cliente à lista
                        }
                    }
                }
            }

            return clients.Count > 0 ? clients : null;  // Retorna a lista de clientes encontrados, ou null se não houver
        }

        //Método para buscar um cliente por CNPJ
        private List<Client> SearchByCnpj(string cnpj)
        {
            // Remove a formatação do CNPJ para garantir que a busca seja feita apenas com os números
            string cleanedCnpj = new string(cnpj.Where(char.IsDigit).ToArray());
            var clients = new List<Client>();  // Lista para armazenar os clientes encontrados

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
                        while (reader.Read())  // While para percorrer todos os resultados
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

                            // Busca o endereço associado ao cliente em uma nova conexão
                            using (NpgsqlConnection addressConnection = DBConnection.OpenConnection())
                            {
                                client.Address = SearchAddressByClientId(client.Id, addressConnection);
                            }

                            clients.Add(client);  // Adiciona o cliente à lista
                        }
                    }
                }
            }

            return clients.Count > 0 ? clients : null;  // Retorna a lista de clientes encontrados, ou null se não houver
        }

        //Método para buscar um cliente por Nome
        private List<Client> SearchByName(string name)
        {
            var clients = new List<Client>();  // Lista para armazenar os clientes encontrados

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
                        while (reader.Read())  //While para percorrer todos os resultados
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

                            // Busca o endereço associado ao cliente em uma nova conexão
                            using (NpgsqlConnection addressConnection = DBConnection.OpenConnection())
                            {
                                client.Address = SearchAddressByClientId(client.Id, addressConnection);
                            }

                            clients.Add(client);  // Adiciona o cliente à lista
                        }
                    }
                }
            }

            return clients.Count > 0 ? clients : null;  // Retorna a lista de clientes encontrados, ou null se não houver
        }

        //Método para identificar qual busca o usuário está tentando fazer
        public List<Client> SearchByIdentifier(string identifier)
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
                    return SearchByCpf(identifier);  // Retorna um único cliente
                }
                else if (identifier.Length == 14)
                {
                    // Caso tenha 14 dígitos, é CNPJ
                    return SearchByCnpj(identifier);  // Retorna um único cliente
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
                return SearchByName(identifier);  // Retorna uma lista de clientes
            }
        }

    }
}