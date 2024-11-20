using System;
using GerenciadorProdutoECliente.Enums;

namespace GerenciadorProdutoECliente.Models
{
    public class CashMovement
    {
        public int Id { get; set; }                  // ID da movimentação de caixa
        public int OrderId { get; set; }             // ID do Pedido associado à movimentação de caixa
        public decimal Paid { get; set; }            // Valor pago (pagamento do cliente)
        public decimal AmountDue { get; set; }       // Valor total do pedido
        public PaymentMethod PaymentMethod { get; set; } // Método de pagamento (enum)
        public decimal Change { get; set; }          // Troco (se o cliente pagou mais do que o valor do pedido)

        // Relacionamento com a tabela de Pedidos
        public Order Order { get; set; }             // O pedido associado à movimentação de caixa

        // Construtor
        public CashMovement()
        {
            // Inicialização, se necessário
        }

        // Método para calcular o troco (se o cliente pagou mais do que o valor do pedido)
        public void CalculateChange()
        {
            if (Paid > AmountDue)
            {
                Change = Paid - AmountDue;
            }
            else
            {
                Change = 0; // Sem troco se o valor pago não for maior que o valor do pedido
            }
        }
    }
}
