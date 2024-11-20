using System;
using System.Collections.Generic;
using Npgsql;
using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Data;

namespace GerenciadorProdutoECliente.Repositories
{
    public class OrderRepository
    {
        // Método para salvar o pedido no banco de dados e retornar o ID do pedido
        public int Save(Order order)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                NpgsqlTransaction transaction = connection.BeginTransaction(); // Inicia a transação

                try
                {
                    // Inserir o pedido na tabela 'pedidos' e obter o ID do pedido
                    string query = @"
                INSERT INTO pedidos (cliente_id, data_pedido, valor_total, cancelado, finalizado)
                VALUES (@ClientId, @OrderDate, @TotalAmount, @Canceled, @Finalized)
                RETURNING id;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@ClientId", order.ClientId);
                        command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        command.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                        command.Parameters.AddWithValue("@Canceled", order.Canceled);
                        command.Parameters.AddWithValue("@Finalized", order.Finalized);

                        // Obter o ID do pedido gerado
                        order.Id = (int)command.ExecuteScalar();  // Retorna o ID do pedido inserido
                    }

                    // Salvar os itens do pedido
                    foreach (OrderItem item in order.OrderItems)
                    {
                        string itemQuery = @"
                    INSERT INTO pedidos_itens (pedido_id, produto_id, quantidade, valor_unitario, valor_total)
                    VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice, @TotalValue);";

                        using (NpgsqlCommand itemCommand = new NpgsqlCommand(itemQuery, connection, transaction))
                        {
                            itemCommand.Parameters.AddWithValue("@OrderId", order.Id);
                            itemCommand.Parameters.AddWithValue("@ProductId", item.ProductId);
                            itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                            itemCommand.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                            itemCommand.Parameters.AddWithValue("@TotalValue", item.TotalValue);

                            itemCommand.ExecuteNonQuery(); // Executa o comando de inserção
                        }
                    }

                    // Commit da transação
                    transaction.Commit();

                    // Retorna o ID do pedido que foi inserido no banco
                    return order.Id;
                }
                catch (Exception ex)
                {
                    // Em caso de erro, faz rollback da transação
                    transaction.Rollback();
                    Console.WriteLine($"Erro ao salvar pedido: {ex.Message}");
                    return 0; // Retorna 0 em caso de erro
                }
            }
        }

        public bool Update(Order order)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                NpgsqlTransaction transaction = connection.BeginTransaction(); // Inicia a transação

                try
                {
                    // Atualizar o pedido na tabela 'pedidos'
                    string query = @"
            UPDATE pedidos
            SET cliente_id = @ClientId, 
                data_pedido = @OrderDate, 
                valor_total = @TotalAmount, 
                cancelado = @Canceled, 
                finalizado = @Finalized
            WHERE id = @OrderId;";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@OrderId", order.Id);
                        command.Parameters.AddWithValue("@ClientId", order.ClientId);
                        command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        command.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                        command.Parameters.AddWithValue("@Canceled", order.Canceled);
                        command.Parameters.AddWithValue("@Finalized", order.Finalized);

                        int affectedRows = command.ExecuteNonQuery();  // Executa o comando de atualização

                        // Se nenhuma linha foi afetada, significa que o pedido não foi encontrado
                        if (affectedRows == 0)
                        {
                            return false;  // Retorna falso se o pedido não existir no banco
                        }
                    }

                    // Atualizar os itens do pedido na tabela 'pedidos_itens'
                    foreach (OrderItem item in order.OrderItems)
                    {
                        string itemQuery = @"
                INSERT INTO pedidos_itens (pedido_id, produto_id, quantidade, valor_unitario, valor_total)
                VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice, @TotalValue)
                ON CONFLICT (pedido_id, produto_id) 
                DO UPDATE SET quantidade = @Quantity, valor_unitario = @UnitPrice, valor_total = @TotalValue;";

                        using (NpgsqlCommand itemCommand = new NpgsqlCommand(itemQuery, connection, transaction))
                        {
                            itemCommand.Parameters.AddWithValue("@OrderId", order.Id);
                            itemCommand.Parameters.AddWithValue("@ProductId", item.ProductId);
                            itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                            itemCommand.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                            itemCommand.Parameters.AddWithValue("@TotalValue", item.TotalValue);

                            itemCommand.ExecuteNonQuery(); // Executa o comando de atualização ou inserção de item
                        }
                    }

                    // Commit da transação
                    transaction.Commit();

                    // Retorna true se a atualização foi bem-sucedida
                    return true;
                }
                catch (Exception ex)
                {
                    // Em caso de erro, faz rollback da transação
                    transaction.Rollback();
                    Console.WriteLine($"Erro ao atualizar pedido: {ex.Message}");
                    return false;  // Retorna falso em caso de erro
                }
            }
        }


        // Método para buscar o pedido por ID
        public Order GetOrderById(int orderId)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
                    SELECT id, cliente_id, data_pedido, data_concluido, cancelado, finalizado, valor_total
                    FROM pedidos
                    WHERE id = @OrderId;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Order order = new Order
                            {
                                Id = reader.GetInt32(0),
                                ClientId = reader.GetInt32(1),
                                OrderDate = reader.GetDateTime(2),
                                CompletionDate = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                Canceled = reader.GetBoolean(4),
                                Finalized = reader.GetBoolean(5),
                                TotalAmount = reader.GetDecimal(6),
                            };

                            // Carregar os itens do pedido
                            order.OrderItems = GetOrderItems(order.Id);
                            return order;
                        }
                    }
                }
            }

            return null;
        }

        // Método para buscar os itens de um pedido
        private List<OrderItem> GetOrderItems(int orderId)
        {
            List<OrderItem> items = new List<OrderItem>();

            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
                    SELECT produto_id, quantidade, valor_unitario, valor_total
                    FROM pedidos_itens
                    WHERE pedido_id = @OrderId;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new OrderItem
                            {
                                ProductId = reader.GetInt32(0),
                                Quantity = reader.GetInt32(1),
                                UnitPrice = reader.GetDecimal(2),
                                TotalValue = reader.GetDecimal(3),
                            });
                        }
                    }
                }
            }

            return items;
        }

        // Método para atualizar o status de finalização do pedido
        public bool UpdateOrderStatus(int orderId, bool finalized)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                // Inicia uma transação
                using (NpgsqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Atualiza o pedido, incluindo a data de conclusão se for finalizado
                        string query = "UPDATE pedidos SET finalizado = @Finalized, " +
                                       "data_concluido = CASE WHEN @Finalized = TRUE THEN CURRENT_DATE ELSE data_concluido END " +
                                       "WHERE id = @OrderId";

                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@OrderId", orderId);
                            command.Parameters.AddWithValue("@Finalized", finalized);

                            // Executa o comando de atualização
                            int rowsAffected = command.ExecuteNonQuery();

                            // Se nenhuma linha for afetada, isso indica que o pedido não foi encontrado
                            if (rowsAffected == 0)
                            {
                                // Faz rollback se não encontrar o pedido
                                transaction.Rollback();
                                return false;
                            }

                            // Se tudo ocorrer bem, comita a transação
                            transaction.Commit();
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Em caso de erro, faz rollback
                        transaction.Rollback();
                        Console.WriteLine($"Erro ao atualizar status do pedido: {ex.Message}");
                        return false;
                    }
                }
            }
        }

    }
}
