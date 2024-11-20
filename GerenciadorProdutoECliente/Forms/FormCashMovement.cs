using GerenciadorProdutoECliente.Enums;
using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Repositories;
using GerenciadorProdutoECliente.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorProdutoECliente.Forms
{
    public partial class FormCashMovement : Form
    {
        private readonly CashMovementService _cashMovementService;  // Serviço para manipular a movimentação de caixa
        private int _orderId;  // ID do pedido
        private decimal _amountDue;  // Valor total do pedido
        private decimal _change;  // Troco calculado
        public FormCashMovement(int orderId)
        {
            InitializeComponent();
            _cashMovementService = new CashMovementService(new CashMovementRepository());  // Inicialização do serviço
            _orderId = orderId;  // Armazenar o ID do pedido
        }

        private void FormCashMovement_Load(object sender, EventArgs e)
        {
            // Carregar os dados do pedido usando o ID
            var cashMovement = _cashMovementService.GetCashMovementByOrderId(_orderId);

            if (cashMovement != null)
            {
                lblOrderId.Text = cashMovement.OrderId.ToString();  // Exibe o ID do pedido
                lblAmountDue.Text = cashMovement.AmountDue.ToString("C2");  // Exibe o valor a pagar
                _amountDue = cashMovement.AmountDue;
            }
            else
            {
                MessageBox.Show("Pedido não encontrado.");
                this.Close();  // Fecha o form se o pedido não for encontrado
            }

            // Preencher comboBox com os métodos de pagamento
            cmbPaymentMethod.Items.AddRange(Enum.GetNames(typeof(PaymentMethod)));
            cmbPaymentMethod.SelectedIndex = 0;  // Seleciona o primeiro item da lista (ex: Dinheiro)
        }

        private void btnFinalizePayment_Click(object sender, EventArgs e)
        {
            // Verificar se o valor pago foi informado corretamente
            if (string.IsNullOrWhiteSpace(txtPaid.Text) || !decimal.TryParse(txtPaid.Text, out decimal paidAmount))
            {
                MessageBox.Show("Por favor, insira o valor pago.");
                return;
            }

            // Verificar se o valor pago é suficiente para cobrir o valor do pedido
            if (paidAmount < _amountDue)
            {
                MessageBox.Show("O valor pago é insuficiente para cobrir o valor do pedido.");
                return;
            }

            // Criar a movimentação de caixa com os dados do pagamento
            CashMovement cashMovement = new CashMovement
            {
                OrderId = _orderId,
                Paid = paidAmount,
                AmountDue = _amountDue,
                PaymentMethod = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), cmbPaymentMethod.SelectedItem.ToString())
            };

            // Processar a movimentação de caixa e registrar no banco de dados (o cálculo do troco já é feito no método)
            bool isSuccessful = _cashMovementService.ProcessCashMovement(cashMovement);

            if (isSuccessful)
            {
                // Exibe o troco calculado automaticamente pelo método
                lblChange.Text = cashMovement.Change.ToString("C2");
                MessageBox.Show("Pagamento registrado com sucesso!");
                this.Close();  // Fechar o formulário após o pagamento ser registrado
            }
            else
            {
                MessageBox.Show("Erro ao registrar o pagamento.");
            }
        }

    }
}
