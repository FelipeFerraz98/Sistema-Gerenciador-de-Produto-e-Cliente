using System;

namespace GerenciadorProdutoECliente.Models
{
    public class Product
    {
        public int Id { get; set; }              // ID único do produto
        public string Name { get; set; }         // Nome do produto
        public int StockQuantity { get; set; }   // Quantidade em estoque
        public decimal UnitPrice { get; set; }   // Preço unitário do produto
        public string Description { get; set; }  // Descrição do produto

        // Método para diminuir o estoque após uma venda
        public void DecreaseStock(int quantity)
        {
            if (quantity > StockQuantity)
                throw new InvalidOperationException("Não há estoque suficiente para a venda.");

            StockQuantity -= quantity;
        }
    }
}