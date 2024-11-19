using System;
using Npgsql;
using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Data;

namespace GerenciadorProdutoECliente.Repositories
{
    public class OrderItemRepository
    {
        // Método para adicionar um item ao pedido
        public bool AddItem(OrderItem item)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
                    INSERT INTO pedidos_itens (pedido_id, produto_id, quantidade, valor_unitario, valor_total)
                    VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice, @TotalValue);";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", item.OrderId);
                    command.Parameters.AddWithValue("@ProductId", item.ProductId);
                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                    command.Parameters.AddWithValue("@TotalValue", item.TotalValue);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para atualizar a quantidade e o valor total de um item
        public bool UpdateItem(OrderItem item)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
                    UPDATE pedidos_itens
                    SET quantidade = @Quantity, valor_total = @TotalValue
                    WHERE pedido_id = @OrderId AND produto_id = @ProductId;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", item.OrderId);
                    command.Parameters.AddWithValue("@ProductId", item.ProductId);
                    command.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command.Parameters.AddWithValue("@TotalValue", item.TotalValue);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para remover um item do pedido
        public bool RemoveItem(int orderId, int productId)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = "DELETE FROM pedidos_itens WHERE pedido_id = @OrderId AND produto_id = @ProductId;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@ProductId", productId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
