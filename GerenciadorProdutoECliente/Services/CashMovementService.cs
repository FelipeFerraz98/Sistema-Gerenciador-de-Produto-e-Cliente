using System;
using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Repositories;

namespace GerenciadorProdutoECliente.Services
{
    public class CashMovementService
    {
        private readonly CashMovementRepository cashMovementRepository;

        public CashMovementService(CashMovementRepository cashMovementRepository)
        {
            this.cashMovementRepository = cashMovementRepository;
        }

        // Método para processar a movimentação de caixa
        public bool ProcessCashMovement(CashMovement cashMovement)
        {
            // Verificar se o valor pago é suficiente para cobrir o valor do pedido
            if (cashMovement.Paid < cashMovement.AmountDue)
            {
                // Se o valor pago for menor que o valor do pedido, retornar falso
                return false; // Não é possível processar o pagamento
            }

            // Calcular o troco
            cashMovement.CalculateChange();

            // Registrar a movimentação de caixa, incluindo o troco
            return cashMovementRepository.AddCashMovement(cashMovement);
        }

        // Método para obter a movimentação de caixa por ID do pedido
        public CashMovement GetCashMovementByOrderId(int orderId)
        {
            return cashMovementRepository.GetCashMovementByOrderId(orderId);
        }
    }
}
