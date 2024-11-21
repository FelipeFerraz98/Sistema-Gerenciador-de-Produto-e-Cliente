using GerenciadorProdutoECliente.Enums;
using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Repositories;
using GerenciadorProdutoECliente.Services;
using GerenciadorProdutoECliente.Utils;
using Org.BouncyCastle.Asn1.X509;
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
                lblAmountDue.Text = ConvertCurrency.ConvertToReal(order.TotalAmount);  // Exibe o valor a pagar
                _amountDue = order.TotalAmount;

                // Preencher o ListBox com os itens do pedido
                lstOrderItems.Items.Clear();  // Limpar a lista antes de adicionar os novos itens
                foreach (OrderItem item in order.OrderItems)
                {
                    // Busca o produto pelo ID do produto
                    string idString = item.ProductId.ToString();  // Convertendo o ID do produto para string

                    // Obtém o produto relacionado ao item
                    item.Product = _orderService.GetProductByIdentifier(idString);

                    string unitPrice = ConvertCurrency.ConvertToReal(item.UnitPrice); // Formata o valor unitário

                    string totalValue = ConvertCurrency.ConvertToReal(item.TotalValue); // Formata o valor total

                    // Verifica se o produto foi encontrado e adiciona à lista
                    if (item.Product != null)
                    {
                        lstOrderItems.Items.Add($"{item.Product.Name} - {item.Quantity} x {unitPrice} = {totalValue}");
                    }
                    else
                    {
                        lstOrderItems.Items.Add($"Produto não encontrado para o item - {item.Quantity} x {unitPrice} = {totalValue}");
                    }
                }
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
        private void OnOrderCompleted(decimal paidAmount)
        {
            // Obter o pedido do OrderService usando o ID do pedido
            Order order = _orderService.GetOrderById(_orderId);

            if (order != null)
            {
                // Gerar o relatório do pedido em PDF
                string filePath = $"Order_Report_{order.Id}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf";

                // Criar o PDF
                PDFOrderReport pdfReport = new PDFOrderReport(order, paidAmount);
                pdfReport.GenerateReport(filePath);

                // Exibir uma mensagem de sucesso
                MessageBox.Show($"Invoice gerado com sucesso! Salvo em {filePath}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opcional: abrir o arquivo PDF gerado
                System.Diagnostics.Process.Start(filePath);

                Form currentForm = this; // Ou outro formulário atual se necessário
                Form newForm = new FormOrder(); // Cria uma nova instância de FormOrder

                FormManager.SwitchForm(currentForm, newForm);
            }
            else
            {
                MessageBox.Show("Pedido não encontrato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para diminuir a quantidade de produto no estoque após finalizar o pagamento
        private void DeacreaseProductStock()
        {
            //Instancia OrderService para pegar o ID do pedido e localizar os produtos pelo Id
            Order order = _orderService.GetOrderById(_orderId);

            //Instancia ProductService para poder usar o método de tirar produtos do estoque a partir do ID
            ProductService _productService = new ProductService( new ProductRepository());

            foreach (OrderItem item in order.OrderItems) // Percorre todos os produtos na lista
            {
                _productService.DecreaseProductStock(item.ProductId, item.Quantity); // Diminui o produto no estoque
            }
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

                // Método para diminuir a quantidade de produto no estoque após finalizar o pagamento
                DeacreaseProductStock(); 

                OnOrderCompleted(paidAmount);
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
                    // Calcula o troco
                    string change = ConvertCurrency.ConvertToReal(paidAmount - _amountDue); // Formata para Real
                    lblChange.Text = change;  // Exibe o troco na label
                }
                else
                {
                    lblChange.Text = "R$ 0,00";  // Se o valor pago for menor, mostrar troco zero
                }
            }
            else
            {
                lblChange.Text = "R$ 0,00";  // Caso o valor seja inválido, mostrar troco zero
            }
        }
    }
}
