using System;
using System.Collections.Generic;

namespace GerenciadorProdutoECliente.Models
{
    public class Order
    {
        public int Id { get; set; }              // ID único do pedido
        public int ClientId { get; set; }         // ID do cliente que fez o pedido
        public DateTime OrderDate { get; set; }  // Data do pedido
        public DateTime? CompletionDate { get; set; } // Data de conclusão do pedido (null se não finalizado)
        public bool Canceled { get; set; }       // Status de cancelamento do pedido
        public bool Finalized { get; set; }      // Status de finalização do pedido
        public decimal TotalAmount { get; set; } // Valor total do pedido
        public Client Client { get; set; }        // Cliente associado ao pedido
        public List<OrderItem> OrderItems { get; set; } // Lista de itens do pedido

        // Construtor
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        // Método para atualizar o valor total do pedido
        public void UpdateTotalAmount()
        {
            TotalAmount = 0;
            foreach (var item in OrderItems)
            {
                TotalAmount += item.TotalValue;
            }
        }
    }
}
