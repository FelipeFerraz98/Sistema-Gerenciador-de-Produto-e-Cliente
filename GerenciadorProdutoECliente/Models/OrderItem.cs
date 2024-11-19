using System;

namespace GerenciadorProdutoECliente.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }         // ID do pedido ao qual o item pertence
        public int ProductId { get; set; }       // ID do produto que foi comprado
        public int Quantity { get; set; }        // Quantidade do produto no pedido
        public decimal UnitPrice { get; set; }   // Preço unitário do produto no momento da venda
        public decimal TotalValue { get; set; }  // Valor total do item (quantidade * preço unitário)
        public Product Product { get; set; }     // Produto associado ao item

        // Construtor
        public OrderItem()
        {
        }

        // Método para calcular o valor total do item (baseado na quantidade e preço unitário)
        public void CalculateTotalValue()
        {
            TotalValue = Quantity * UnitPrice;
        }
    }
}
