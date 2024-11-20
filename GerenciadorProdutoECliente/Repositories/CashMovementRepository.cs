using System;
using Npgsql;
using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Data;
using GerenciadorProdutoECliente.Enums;

namespace GerenciadorProdutoECliente.Repositories
{
    public class CashMovementRepository
    {
        // Método para adicionar uma movimentação de caixa
        public bool AddCashMovement(CashMovement cashMovement)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
                    INSERT INTO caixa_pedidos (pedido_id, pago, pagar, troco, forma_pagamento)
                    VALUES (@OrderId, @Paid, @AmountDue, @Change, @PaymentMethod);";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", cashMovement.OrderId);
                    command.Parameters.AddWithValue("@Paid", cashMovement.Paid);
                    command.Parameters.AddWithValue("@AmountDue", cashMovement.AmountDue);
                    command.Parameters.AddWithValue("@Change", cashMovement.Change); 
                    command.Parameters.AddWithValue("@PaymentMethod", cashMovement.PaymentMethod.ToString()); // Enum convertido para string

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para obter uma movimentação de caixa pelo ID do pedido
        public CashMovement GetCashMovementByOrderId(int orderId)
        {
            using (NpgsqlConnection connection = DBConnection.OpenConnection())
            {
                string query = @"
                    SELECT id, pedido_id, pago, pagar, troco, forma_pagamento
                    FROM caixa_pedidos
                    WHERE pedido_id = @OrderId;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CashMovement
                            {
                                Id = reader.GetInt32(0),
                                OrderId = reader.GetInt32(1),
                                Paid = reader.GetDecimal(2),
                                AmountDue = reader.GetDecimal(3),
                                Change = reader.GetDecimal(4),
                                PaymentMethod = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), reader.GetString(5)) // Convertendo de string para enum
                            };
                        }
                    }
                }
            }
            return null; // Retorna null se não encontrar movimentação
        }
    }
}
