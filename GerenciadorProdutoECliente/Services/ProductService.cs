using System;
using System.Collections.Generic;
using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Repositories;

namespace GerenciadorProdutoECliente.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Método para adicionar um produto
        public bool AddProduct(Product product)
        {
            try
            {
                // Validação do produto antes de adicionar
                if (product == null)
                {
                    Console.WriteLine("Dados do produto são inválidos.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    Console.WriteLine("O nome do produto não pode ser vazio.");
                    return false;
                }

                if (product.StockQuantity < 0)
                {
                    Console.WriteLine("A quantidade de estoque não pode ser negativa.");
                    return false;
                }

                if (product.UnitPrice <= 0)
                {
                    Console.WriteLine("O preço unitário deve ser maior que zero.");
                    return false;
                }

                // Chama o repositório para adicionar o produto
                return _productRepository.AddProduct(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar produto: {ex.Message}");
                return false;
            }
        }

        // Método para buscar produto por identificador (ID ou nome)
        public Product GetProductByIdentifier(string identifier)
        {
            try
            {
                // Verifica se o identificador está vazio
                if (string.IsNullOrWhiteSpace(identifier))
                {
                    Console.WriteLine("O identificador não pode ser vazio.");
                    return null;
                }

                // Chama o repositório para buscar o produto
                return _productRepository.SearchByIdentifier(identifier);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar produto pelo identificador: {ex.Message}");
                return null;
            }
        }

        // Método para atualizar um produto
        public bool UpdateProduct(Product product)
        {
            try
            {
                // Validação do produto antes de atualizar
                if (product == null)
                {
                    Console.WriteLine("Dados atualizados são inválidos.");
                    return false;
                }

                if (product.Id <= 0)
                {
                    Console.WriteLine("ID do produto inválido.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    Console.WriteLine("O nome do produto não pode ser vazio.");
                    return false;
                }

                if (product.StockQuantity < 0)
                {
                    Console.WriteLine("A quantidade de estoque não pode ser negativa.");
                    return false;
                }

                if (product.UnitPrice <= 0)
                {
                    Console.WriteLine("O preço unitário deve ser maior que zero.");
                    return false;
                }

                // Chama o repositório para atualizar o produto
                return _productRepository.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar produto: {ex.Message}");
                return false;
            }
        }

        // Método para deletar um produto
        public bool DeleteProduct(int productId)
        {
            try
            {
                // Validação do ID do produto
                if (productId <= 0)
                {
                    Console.WriteLine("ID do produto inválido.");
                    return false;
                }

                // Chama o repositório para deletar o produto
                return _productRepository.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar produto: {ex.Message}");
                return false;
            }
        }
    }
}
