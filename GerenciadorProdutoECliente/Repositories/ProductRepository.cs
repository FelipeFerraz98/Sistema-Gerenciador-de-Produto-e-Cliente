using GerenciadorProdutoECliente.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using GerenciadorProdutoECliente.Data;

namespace GerenciadorProdutoECliente.Repositories
{
    public class ProductRepository
    {
        // Adicionar um novo produto
        public bool AddProduct(Product product)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
                INSERT INTO produtos (nome, quantidade_estoque, preco_unitario, descricao) 
                VALUES (@Name, @StockQuantity, @UnitPrice, @Description) 
                RETURNING id;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    // Parâmetros do produto
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                    command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                    command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value); // Se for nulo, passa DBNull

                    // Obtém o ID gerado pelo banco após o INSERT
                    product.Id = (int)command.ExecuteScalar();
                    return true;
                }
            }
        }

        //Buscar um produto pelo ID
        private Product GetProductById(int productId)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = "SELECT id, nome, quantidade_estoque, preco_unitario, descricao FROM produtos WHERE id = @ProductId";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                StockQuantity = reader.GetInt32(2),
                                UnitPrice = reader.GetDecimal(3),
                                Description = reader.IsDBNull(4) ? null : reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        private Product SearchByName(string name)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
SELECT id, nome, quantidade_estoque, preco_unitario, descricao
FROM produtos
WHERE nome ILIKE @Name LIMIT 1";  // Limita a consulta a um único resultado

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", "%" + name + "%");  // Busca por nome parcial

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())  // Se houver pelo menos um resultado
                        {
                            Product product = new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                StockQuantity = reader.GetInt32(2),
                                UnitPrice = reader.GetDecimal(3),
                                Description = reader.IsDBNull(4) ? null : reader.GetString(4)
                            };
                            return product;  // Retorna o produto encontrado
                        }
                    }
                }
            }
            return null; //Retorna null se não encontrar produto

        }

        // Atualizar um produto existente
        public bool UpdateProduct(Product product)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
                UPDATE produtos 
                SET nome = @Name, 
                    quantidade_estoque = @StockQuantity, 
                    preco_unitario = @UnitPrice, 
                    descricao = @Description 
                WHERE id = @ProductId;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", product.Id);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                    command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                    command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Se houve atualização
                }
            }
        }

        // Deletar um produto pelo ID
        public bool DeleteProduct(int productId)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = "DELETE FROM produtos WHERE id = @ProductId;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Se houve deleção
                }
            }
        }

        public Product SearchByIdentifier(string identifier)
        {
            // Remover espaços em branco antes e depois da string
            identifier = identifier.Trim();

            // Verifica se a string está vazia
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentException("O identificador não pode ser vazio.");
            }
            // Tenta verificar se o identificador é numérico
            if (int.TryParse(identifier, out int result))
            {
                return GetProductById(result);
            }
            else
            {
                // Se não for numérico, trata como nome
                return SearchByName(identifier);  // Retorna um produto
            }
        }
    }
}
