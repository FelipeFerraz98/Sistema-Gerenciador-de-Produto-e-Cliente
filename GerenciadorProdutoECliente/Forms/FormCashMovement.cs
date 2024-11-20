using GerenciadorProdutoECliente.Enums;
using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Repositories;
using GerenciadorProdutoECliente.Services;
using System;
using System.Windows.Forms;

namespace GerenciadorProdutoECliente.Forms
{
    public partial class FormCashMovement : Form
    {
        private readonly CashMovementService _cashMovementService;  // Serviço para manipular a movimentação de caixa
        private readonly OrderService _orderService;  // Serviço para manipular o pedido
        private int _orderId;  // ID do pedido
        private decimal _amountDue;  // Valor total do pedido

        // Construtor que recebe o ID do pedido
        public FormCashMovement(int orderId)
        {
            InitializeComponent();
            _cashMovementService = new CashMovementService(new CashMovementRepository());  // Inicialização do serviço de movimentação de caixa
            _orderService = new OrderService(
                new OrderRepository(),
                new OrderItemRepository(),
                new ClientService(new ClientRepository()),
                new ProductService(new ProductRepository()));  // Inicialização do serviço de pedido
            _orderId = orderId;  // Armazenar o ID do pedido
        }

        private void FormCashMovement_Load(object sender, EventArgs e)
        {
            // Carregar os dados do pedido usando o ID
            Order order = _orderService.GetOrderById(_orderId);

            if (order != null)
            {
                // Exibir as informações do pedido
                lblOrderId.Text = order.Id.ToString();  // Exibe o ID do pedido
                lblDataOrder.Text = order.OrderDate.ToString("dd/MM/yyyy");  // Exibe a data do pedido
                lblAmountDue.Text = order.TotalAmount.ToString("C2");  // Exibe o valor a pagar
                _amountDue = order.TotalAmount;
            }
            else
            {
                MessageBox.Show("Pedido não encontrado.");
                this.Close();  // Fecha o formulário se o pedido não for encontrado
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
                // Atualizar o status do pedido para "Finalizado"
                bool isOrderFinalized = _orderService.FinalizeOrder(_orderId);
                if (isOrderFinalized)
                {
                    MessageBox.Show("Pagamento registrado com sucesso e pedido finalizado!");
                }
                else
                {
                    MessageBox.Show("Erro ao finalizar o pedido.");
                }

                this.Close();  // Fechar o formulário após o pagamento ser registrado
            }
            else
            {
                MessageBox.Show("Erro ao registrar o pagamento.");
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            // Verificar se o valor pago foi informado corretamente
            if (decimal.TryParse(txtPaid.Text, out decimal paidAmount))
            {
                // Calcular o troco
                if (paidAmount >= _amountDue)
                {
                    decimal change = paidAmount - _amountDue;
                    lblChange.Text = change.ToString("C2");  // Exibe o troco na label
                }
                else
                {
                    lblChange.Text = "$ 0.00";  // Se o valor pago for menor, mostrar troco zero
                }
            }
            else
            {
                lblChange.Text = "$ 0.00";  // Caso o valor seja inválido, mostrar troco zero
            }
        }
    }
}
