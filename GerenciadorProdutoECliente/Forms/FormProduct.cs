using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Repositories;
using GerenciadorProdutoECliente.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GerenciadorProdutoECliente.Forms
{
    public partial class FormProduct : Form
    {
        private readonly ProductService _productService;
        private int ProductIdSave { get; set; }
        public FormProduct()
        {
            InitializeComponent();
            _productService = new ProductService(new ProductRepository());
            ProductIdSave = 0;
            btnProduct.Enabled = false;
        }
        private void ClearFields()
        {
            txtName.Clear();
            txtStock.Clear();
            txtPrice.Clear();
            txtDescription.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Valida se todos os campos estão preenchidos corretamente
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtStock.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            if (int.TryParse(txtStock.Text, out int stockQuantity) && decimal.TryParse(txtPrice.Text, out decimal unitPrice))
            {
                // Cria um novo produto
                Product newProduct = new Product
                {
                    Name = txtName.Text,
                    StockQuantity = stockQuantity,
                    UnitPrice = unitPrice,
                    Description = txtDescription.Text
                };

                // Chama o serviço para adicionar o produto
                bool success = _productService.AddProduct(newProduct);

                if (success)
                {
                    MessageBox.Show("Produto adicionado com sucesso.");
                    ClearFields(); // Limpar os campos após a adição
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar produto.");
                }
            }
            else
            {
                MessageBox.Show("Verifique os valores de estoque e preço.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string identifier = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(identifier))
            {
                MessageBox.Show("Por favor, informe o nome ou ID do produto.");
                return;
            }

            // Chama o método para buscar o produto através do ProductService
            Product product = _productService.GetProductByIdentifier(identifier);

            if (product != null)
            {
                // Preenche os campos com os dados do produto encontrado
                txtName.Text = product.Name;
                txtStock.Text = product.StockQuantity.ToString();
                txtPrice.Text = product.UnitPrice.ToString("F2");
                txtDescription.Text = product.Description;

                // Salva o ID do produto para edição ou exclusão futura
                ProductIdSave = product.Id;
            }
            else
            {
                MessageBox.Show("Produto não encontrado.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ProductIdSave == 0)
            {
                MessageBox.Show("Faça uma busca antes de atualizar o produto!");
                return;
            }

            // Valida se todos os campos estão preenchidos corretamente
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtStock.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            if (int.TryParse(txtStock.Text, out int stockQuantity) && decimal.TryParse(txtPrice.Text, out decimal unitPrice))
            {
                // Cria um produto para atualizar
                Product productToUpdate = new Product
                {
                    Id = ProductIdSave,
                    Name = txtName.Text,
                    StockQuantity = stockQuantity,
                    UnitPrice = unitPrice,
                    Description = txtDescription.Text
                };

                // Chama o serviço para atualizar o produto
                bool success = _productService.UpdateProduct(productToUpdate);

                if (success)
                {
                    MessageBox.Show("Produto atualizado com sucesso.");
                    ClearFields(); // Limpar os campos após a atualização
                    ProductIdSave = 0;
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar produto.");
                }
            }
            else
            {
                MessageBox.Show("Verifique os valores de estoque e preço.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ProductIdSave == 0)
            {
                MessageBox.Show("Faça uma busca antes de deletar o produto!");
                return;
            }

            // Chama o serviço para deletar o produto
            bool success = _productService.DeleteProduct(ProductIdSave);

            if (success)
            {
                MessageBox.Show("Produto removido com sucesso.");
                ProductIdSave = 0;
                ClearFields(); // Limpar os campos após a exclusão
            }
            else
            {
                MessageBox.Show("Erro ao remover produto.");
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Form currentForm = this; // Ou outro formulário atual se necessário
            Form newForm = new FormClient(); // Cria uma nova instância de FormClient

            FormManager.SwitchForm(currentForm, newForm);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Form currentForm = this; // Ou outro formulário atual se necessário
            Form newForm = new FormOrder(); // Cria uma nova instância de FormOrder

            FormManager.SwitchForm(currentForm, newForm);
        }
    }
}
