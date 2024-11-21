using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Repositories;
using System;
using System.Collections.Generic;

namespace GerenciadorProdutoECliente.Services
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository;
        private readonly OrderItemRepository orderItemRepository;
        private readonly ClientService clientService;
        private readonly ProductService productService;

        public OrderService(
            OrderRepository orderRepository,
            OrderItemRepository orderItemRepository,
            ClientService clientService,
            ProductService productService)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.clientService = clientService;
            this.productService = productService;
        }

        // Método para buscar o cliente e validar se existe
        public Client GetClientByCpfOrCnpj(string cpfCnpj)
        {
            return clientService.GetClientByCpfOrCnpj(cpfCnpj);
        }

        // Método para buscar o produto por ID ou nome
        public Product GetProductByIdentifier(string identifier)
        {
            return productService.GetProductByIdentifier(identifier);
        }

        // Método para criar e salvar o pedido
        public int CreateOrder(Order order)
        {
            // Validação do pedido
            if (order == null || order.ClientId == 0 || order.OrderItems.Count == 0)
            {
                return 0; // Não pode criar pedido sem cliente ou itens
            }

            // Salvar o pedido no banco de dados
            int orderSaved = orderRepository.Save(order);
            if (orderSaved != 0)
            {
                return orderSaved;
            }
            return 0;
        }

        // Método para adicionar um item ao pedido
        public bool AddItemToOrder(Order order, int productId, int quantity, decimal unitPrice)
        {
            Product product = productService.GetProductByIdentifier(productId.ToString());
            if (product == null)
            {
                return false; // Produto não encontrado
            }

            // Cria o item do pedido
            OrderItem newItem = new OrderItem
            {
                OrderId = order.Id,
                ProductId = product.Id,
                Quantity = quantity,
                UnitPrice = unitPrice // Preço unitário agora vem da entrada do usuário
            };

            // Calcular o valor total do item
            newItem.CalculateTotalValue();

            // Adiciona o item ao pedido
            order.OrderItems.Add(newItem);

            // Salvar o item no banco
            return orderItemRepository.AddItem(newItem);
        }

        // Método para atualizar o total do pedido
        public void UpdateTotalAmount(Order order)
        {
            order.UpdateTotalAmount(); // Atualiza o valor total do pedido
        }

        // Método para salvar o pedido final com seus itens
        public int SaveOrder(Order order)
        {
            // Valida se o pedido tem pelo menos um item
            if (order.OrderItems.Count == 0)
            {
                return 0; // Não pode salvar pedido sem itens
            }

            // Atualiza o total antes de salvar
            UpdateTotalAmount(order);
            return CreateOrder(order); // Chama o método para criar e salvar o pedido
        }

        public bool UpdateOrder(Order order)
        {
            if (order != null)
            {
                return orderRepository.Update(order);
            }

            return false;
        }

        // Método para remover um item do pedido
        public bool RemoveItemFromOrder(Order order, int productId)
        {
            // Encontrar o item no pedido
            OrderItem itemToRemove = order.OrderItems.Find(item => item.ProductId == productId);
            if (itemToRemove != null)
            {
                order.OrderItems.Remove(itemToRemove);
                return orderItemRepository.RemoveItem(order.Id, productId);
            }
            return false;
        }

        // Método para editar um item do pedido
        public bool EditItemInOrder(Order order, int productId, int newQuantity, decimal newUnitPrice)
        {
            // Encontrar o item no pedido
            OrderItem itemToEdit = order.OrderItems.Find(item => item.ProductId == productId);
            if (itemToEdit != null)
            {
                itemToEdit.Quantity = newQuantity;
                itemToEdit.UnitPrice = newUnitPrice; // Atualizar o preço unitário
                itemToEdit.CalculateTotalValue(); // Recalcular o valor total do item

                // Atualiza o item no banco de dados
                return orderItemRepository.UpdateItem(itemToEdit);
            }
            return false;
        }

        // Método para buscar um pedido pelo ID
        public Order GetOrderById(int orderId)
        {
            // Chama o repositório para buscar o pedido no banco de dados
            return orderRepository.GetOrderById(orderId);
        }

        // Método para tratar a lógica de negócios ao atualizar o status de finalização do pedido
        public bool FinalizeOrder(int orderId)
        {
            // Lógica de negócio: por exemplo, verifica se o pedido pode ser finalizado
            if (orderId <= 0)
            {
                Console.WriteLine("ID do pedido inválido.");
                return false;
            }

            // Se a lógica de negócio passar, chamamos o repositório para atualizar o status
            bool result = orderRepository.UpdateOrderStatus(orderId, true);

            // Retornamos o resultado da operação
            return result;
        }
    }
}
