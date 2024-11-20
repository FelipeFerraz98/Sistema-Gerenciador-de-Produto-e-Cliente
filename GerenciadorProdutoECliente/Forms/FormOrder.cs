using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Repositories;
using GerenciadorProdutoECliente.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GerenciadorProdutoECliente.Forms
{
    public partial class FormOrder : Form
    {
        private OrderService orderService;
        private Order currentOrder;
        private OrderItem currentItem;
        private int OrderIdSave { get; set; }
        public FormOrder()
        {
            InitializeComponent();

            // Inicializando os repositórios
            orderService = new OrderService(
                new OrderRepository(),
                new OrderItemRepository(),
                new ClientService(new ClientRepository()),
                new ProductService(new ProductRepository())
            );
            currentOrder = new Order();
            currentItem = new OrderItem();

            // Inicializa o formulário com os componentes desabilitados
            DisableAllControls();
        }

        // Desabilita todos os controles, exceto a busca de cliente
        private void DisableAllControls()
        {
            txtProductSearch.Enabled = false;
            btnSearchProduct.Enabled = false;
            txtQuantity.Enabled = false;
            btnAddProductToOrder.Enabled = false;
            btnRemoveItem.Enabled = false;
            btnEditItem.Enabled = false;
            btnSave.Enabled = false;
            lstOrderItems.Enabled = false;
            btnGoToCashier.Enabled = false;
            btnNewOrder.Enabled = false;
            ClearProductFields();
            ClearForm();
        }

        // Habilita os controles necessários após criar o pedido
        private void EnableControls()
        {
            txtProductSearch.Enabled = true;
            btnSearchProduct.Enabled = true;
            txtQuantity.Enabled = true;
            btnAddProductToOrder.Enabled = true;
            btnRemoveItem.Enabled = true;
            btnEditItem.Enabled = true;
            btnSave.Enabled = true;
            btnNewOrder.Enabled = true;
            btnGoToCashier.Enabled= true;
            lstOrderItems.Enabled = true;
        }

        // Limpa os campos de produto
        private void ClearProductFields()
        {
            lblProduct.Text = "Nome do Produto";
            lblProductId.Text = string.Empty;
            lblProductPrice.Text = "0.00";
            lblProductTotalPrice.Text = "Preço total do produto: 0.00";
            txtProductSearch.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            currentItem = new OrderItem(); // Limpa o item atual após a adição
        }

        // Limpa o formulário
        private void ClearForm()
        {
            txtClientIdentifier.Clear();
            lblClientName.Text = "Pedido de:";
            lblTotalAmount.Text = "0.00";
            lstOrderItems.Items.Clear();
        }

        private void btnSearchClient_Click(object sender, EventArgs e)
        {
            string clientIdentifier = txtClientIdentifier.Text;

            if (string.IsNullOrWhiteSpace(clientIdentifier))
            {
                MessageBox.Show("Por favor, insira o CPF ou CNPJ.");
                return;
            }

            // Utiliza o método de busca do OrderService
            Client client = orderService.GetClientByIdentifier(clientIdentifier);

            if (client != null)
            {
                lblClientName.Text = $"Pedido de: {client.Name}"; // Exibe o nome do cliente na tela
                currentOrder.ClientId = client.Id; // Associa o cliente ao pedido
                currentOrder.Client = client; // Armazena o cliente completo no pedido
                btnNewOrder.Enabled = true; // Habilita o botão "Criar Pedido"
            }
            else
            {
                MessageBox.Show("Cliente não encontrado.");
                lblClientName.Text = "Pedido de: ";
                btnNewOrder.Enabled = false;
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            if (currentOrder.ClientId == 0)
            {
                MessageBox.Show("Por favor, selecione um cliente antes de criar o pedido.");
                return;
            }

            // Cria um novo pedido
            currentOrder = new Order
            {
                ClientId = currentOrder.ClientId,
                OrderDate = DateTime.Now
            };

            lblTotalAmount.Text = "0.00"; // Zera o total do pedido
            lstOrderItems.Items.Clear(); // Limpa a lista de itens
            btnNewOrder.Enabled = false; // Desabilita o botão de criar pedido após o pedido ser criado

            // Habilita os controles necessários
            EnableControls();
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            string productIdentifier = txtProductSearch.Text;

            if (string.IsNullOrWhiteSpace(productIdentifier))
            {
                MessageBox.Show("Por favor, insira o nome ou ID do produto.");
                return;
            }

            // Utiliza o método de busca do OrderService
            Product product = orderService.GetProductByIdentifier(productIdentifier);

            if (product != null)
            {
                lblProduct.Text = product.Name;
                lblProductId.Text = product.Id.ToString();
                lblProductPrice.Text = product.UnitPrice.ToString("C");
                currentItem.Product = product;
                currentItem.ProductId = product.Id;
                currentItem.UnitPrice = product.UnitPrice;
            }
            else
            {
                MessageBox.Show("Produto não encontrado.");
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (currentItem.Product != null && int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
            {
                decimal totalProductPrice = currentItem.UnitPrice * quantity; // Calculando o preço total
                lblProductTotalPrice.Text = $"Preço total do produto: {totalProductPrice:C}"; // Atualizando o label com o valor calculado
            }
            else
            {
                lblProductTotalPrice.Text = "Preço total do produto: 0.00"; // Se não houver quantidade válida
            }
        }

        private void btnAddProductToOrder_Click(object sender, EventArgs e)
        {
            if (currentItem.Product == null)
            {
                MessageBox.Show("Por favor, selecione um produto primeiro.");
                return;
            }

            if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
            {
                // Verifica a quantidade disponível no estoque
                Product product = currentItem.Product;
                if (quantity > product.StockQuantity)
                {
                    MessageBox.Show($"Quantidade solicitada ({quantity}) excede o estoque disponível ({product.StockQuantity}).");
                    return;
                }

                currentItem.Quantity = quantity;
                currentItem.CalculateTotalValue();

                // Verifica se o item já existe na lista e atualiza ou adiciona
                OrderItem existingItem = currentOrder.OrderItems.FirstOrDefault(item => item.ProductId == currentItem.ProductId);
                if (existingItem != null)
                {
                    existingItem.Quantity = currentItem.Quantity; // Atualiza a quantidade
                    existingItem.CalculateTotalValue(); // Recalcula o valor total
                    lstOrderItems.Items[lstOrderItems.SelectedIndex] = $"{existingItem.Product.Name} - {existingItem.Quantity} x {existingItem.UnitPrice:C} = {existingItem.TotalValue:C}";
                }
                else
                {
                    // Adiciona o novo item
                    currentOrder.OrderItems.Add(currentItem);

                    // Atualiza a lista visual de itens do pedido
                    lstOrderItems.Items.Add($"{currentItem.Product.Name} - {currentItem.Quantity} x {currentItem.UnitPrice:C} = {currentItem.TotalValue:C}");
                }

                // Atualiza o total do pedido
                orderService.UpdateTotalAmount(currentOrder);
                lblTotalAmount.Text = currentOrder.TotalAmount.ToString("C");

                // Limpa os campos para o próximo item
                ClearProductFields();
            }
            else
            {
                MessageBox.Show("Por favor, insira uma quantidade válida.");
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (lstOrderItems.SelectedIndex >= 0)
            {
                // Remove o item da lista
                currentOrder.OrderItems.RemoveAt(lstOrderItems.SelectedIndex);

                // Atualiza a lista visual de itens do pedido
                lstOrderItems.Items.RemoveAt(lstOrderItems.SelectedIndex);

                // Recalcula o total do pedido
                orderService.UpdateTotalAmount(currentOrder);
                lblTotalAmount.Text = currentOrder.TotalAmount.ToString("C");
            }
            else
            {
                MessageBox.Show("Por favor, selecione um item para remover.");
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (lstOrderItems.SelectedIndex >= 0)
            {
                // Obtém o item selecionado
                OrderItem selectedItem = currentOrder.OrderItems[lstOrderItems.SelectedIndex];

                // Preenche os campos com as informações do item
                lblProduct.Text = selectedItem.Product.Name;
                lblProductId.Text = selectedItem.ProductId.ToString();
                lblProductPrice.Text = selectedItem.UnitPrice.ToString("C");
                txtQuantity.Text = selectedItem.Quantity.ToString();

                // Atualiza o item atual para edição
                currentItem = selectedItem;
            }
            else
            {
                MessageBox.Show("Por favor, selecione um item para editar.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentOrder.OrderItems.Count > 0)
            {
                // Chama o serviço para salvar o pedido
                OrderIdSave = orderService.SaveOrder(currentOrder);

                if (OrderIdSave != 0)
                {
                    MessageBox.Show("Pedido salvo com sucesso!");
                    lblOrderId.Text = OrderIdSave.ToString();
                }
                else
                {
                    MessageBox.Show("Erro ao salvar o pedido.");
                    DisableAllControls();
                }
            }
            else
            {
                MessageBox.Show("Por favor, adicione ao menos um produto ao pedido.");
            }      
        }

        private void btnGoToCashier_Click(object sender, EventArgs e)
        {
            if (OrderIdSave == 0)
            {
                MessageBox.Show("Por favor, finalize o pedido antes de ir para o caixa.");
                return;
            }

            // Criação do formulário de movimentação de caixa, passando o ID do pedido
            FormCashMovement formCashMovement = new FormCashMovement(OrderIdSave);

            // Exibir o formulário de movimentação de caixa
            formCashMovement.Show();

            // Ocultar o formulário atual (FormOrder)
            this.Hide();
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtOrderIdSearch.Text, out int orderId) && orderId > 0)
            {
                // Busca o pedido pelo ID
                currentOrder = orderService.GetOrderById(orderId);

                if (currentOrder != null)
                {
                    // Preenche os campos do formulário com as informações do pedido
                    lblClientName.Text = $"Pedido de: {currentOrder.Client?.Name ?? "Desconhecido"}";
                    lblTotalAmount.Text = currentOrder.TotalAmount.ToString("C");

                    // Preenche a lista de itens do pedido
                    lstOrderItems.Items.Clear();
                    foreach (var item in currentOrder.OrderItems)
                    {
                        // Busca o produto usando o ID do produto
                        string idString = item.ProductId.ToString();
                        item.Product = orderService.GetProductByIdentifier(idString);

                        // Verifica se o produto foi encontrado e adiciona à lista
                        if (item.Product != null)
                        {
                            lstOrderItems.Items.Add($"{item.Product.Name} - {item.Quantity} x {item.UnitPrice:C} = {item.TotalValue:C}");
                        }
                        else
                        {
                            lstOrderItems.Items.Add($"Produto não encontrado para o item - {item.Quantity} x {item.UnitPrice:C} = {item.TotalValue:C}");
                        }
                    }
                    OrderIdSave = currentOrder.Id;

                    // Habilita os controles para edição
                    EnableControls();
                    btnSave.Enabled = false;  // Desabilita o botão "Salvar" quando estamos editando um pedido existente
                    btnUpdateOrder.Enabled = true; // Habilita o botão "Atualizar" para pedidos existentes
                    btnNewOrder.Enabled = false; // Desabilita o botão "Novo Pedido" enquanto estamos editando
                }
                else
                {
                    MessageBox.Show("Pedido não encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um ID de pedido válido.");
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (currentOrder != null && currentOrder.OrderItems.Count > 0)
            {
                // Atualiza o pedido no banco de dados com os dados editados
                bool isUpdated = orderService.UpdateOrder(currentOrder);

                if (isUpdated)
                {
                    MessageBox.Show("Pedido atualizado com sucesso!");
                    lblOrderId.Text = currentOrder.Id.ToString(); // Exibe o ID do pedido atualizado
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar o pedido.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, adicione ao menos um produto ao pedido.");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtOrderIdSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblOrderId_Click(object sender, EventArgs e)
        {

        }

        private void lblProductPrice_Click(object sender, EventArgs e)
        {

        }

        private void lblProductId_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalAmount_Click(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void lblProductTotalPrice_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblProduct_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblClientName_Click(object sender, EventArgs e)
        {

        }

        private void lstOrderItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtClientIdentifier_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblClient_Click(object sender, EventArgs e)
        {

        }
    }
}
