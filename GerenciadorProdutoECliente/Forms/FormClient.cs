﻿using GerenciadorProdutoECliente.Enums;
using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Repositories;
using GerenciadorProdutoECliente.Services;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GerenciadorProdutoECliente.Utils;


namespace GerenciadorProdutoECliente.Forms
{
    public partial class FormClient : MaterialForm
    {
        private readonly ClientService _clientService;
        private readonly CepService _cepService;
        private int ClientIdSave { get; set; }

        public FormClient()
        {
            InitializeComponent();
            InitializeMaterialSkin();
            _clientService = new ClientService(new ClientRepository());
            ClientIdSave = 0;
            btnClient.Enabled = false;
            _cepService = new CepService(); // Inicializa o Service

            rbtnIndividual.Checked = true;

            // Remove o título da janela
            this.Text = ""; // Deixa o título vazio

        }
        private void InitializeMaterialSkin()
        {
            // Cria o materialSkinManager e define o tema
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // Ou LIGHT
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue500, Accent.Blue400, TextShade.WHITE);
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtCpfCnpj.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtZipCode.Clear();
            txtStreet.Clear();
            txtNumber.Clear();
            txtComplement.Clear();
            txtNeighborhood.Clear();
            txtCity.Clear();
            txtState.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Determina o tipo de cliente baseado no radio button
            ClientType clientType = rbtnIndividual.Checked ? ClientType.Individual : ClientType.LegalEntity;

            //Remove espaço no começo e no final
            string cpfCnpj = txtCpfCnpj.Text.Trim();

            // Remove qualquer caractere que não seja número
            cpfCnpj = new string(cpfCnpj.Where(char.IsDigit).ToArray());

            // Chama o método de validação de CPF/CNPJ do ClientService
            bool isValid =  _clientService.ValidateCpfOrCnpj(cpfCnpj, clientType);
            if (!isValid)
            {
                MessageBox.Show("CPF/CNPJ INVÁLIDO");
            }

            //Remove espaço no começo e no final
            string zipCode = txtZipCode.Text.Trim();

            // Remove qualquer caractere que não seja número (incluindo o '-')
            zipCode = new string(zipCode.Where(char.IsDigit).ToArray());

            //Remove espaço no começo e no final
            string phone = txtPhone.Text.Trim();

            // Remove qualquer caractere que não seja número (incluindo o '-')
            phone = new string(phone.Where(char.IsDigit).ToArray());

            // Cria um novo cliente
            Client newClient = new Client
            {
                Name = txtName.Text,
                Cpf = clientType == ClientType.Individual && cpfCnpj.Length == 11 ? cpfCnpj : null,
                Cnpj = clientType == ClientType.LegalEntity && cpfCnpj.Length == 14 ? cpfCnpj : null,
                Email = txtEmail.Text,
                ClientType = clientType,
                Phone = phone,
                Address = new Address
                {
                    ZipCode = zipCode,
                    Street = txtStreet.Text,
                    Number = txtNumber.Text,
                    Complement = txtComplement.Text,
                    Neighborhood = txtNeighborhood.Text,
                    City = txtCity.Text,
                    State = txtState.Text
                }
            };

            // Chama o serviço para adicionar o cliente
            bool success = _clientService.AddClient(newClient);

            if (success)
            {
                MessageBox.Show("Cliente adicionado com sucesso.");
                ClearFields(); // Limpar os campos após a adição
            }
            else if(!success && isValid)
            {
                MessageBox.Show("Erro ao adicionar cliente.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string identifier = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(identifier))
            {
                MessageBox.Show("Por favor, informe um CPF, CNPJ ou Nome.");
                return;
            }

            // Chama o método para buscar o cliente através do ClientService
            List<Client> clients = _clientService.GetClientByIdentifier(identifier);

            // Limpa a lista de resultados antes de mostrar
            lstClients.Items.Clear();


            if (clients != null)
            {
                foreach (var client in clients)
                {
                    // Verifica se o CPF não é nulo antes de tentar formatar
                    string cpfCnpj = null;

                    if (!string.IsNullOrEmpty(client.Cpf)) // Verifica se o CPF existe
                    {
                        cpfCnpj = Formatter.FormatCpf(client.Cpf);
                    }
                    else if (!string.IsNullOrEmpty(client.Cnpj)) // Caso CPF seja nulo, verifica se o CNPJ existe
                    {
                        cpfCnpj = Formatter.FormatCnpj(client.Cnpj);
                    }

                    // Verifica se o CPF não é nulo antes de tentar formatar
                    string phone = null;

                    if (!string.IsNullOrEmpty(client.Phone)) // Verifica se o CPF existe
                    {
                        phone = Formatter.FormatCpf(client.Phone);
                    }

                    if (cpfCnpj != null) // Caso não tenha nem CPF nem CNPJ, mostra uma mensagem
                    {
                        string displayText = $"{client.Name} | {cpfCnpj} | {client.Phone}";
                        lstClients.Items.Add(displayText);
                    }
                }
            }
            else
            {
                MessageBox.Show("Cliente não encontrado.");
            }
        }

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClients.SelectedItem != null)
            {
                string selectedClientInfo = lstClients.SelectedItem.ToString();

                // Extrair o nome, CPF/CNPJ e telefone da string exibida
                string[] clientDetails = selectedClientInfo.Split('|');
                string clientIdentifier = clientDetails[1].Trim();  // CPF ou CNPJ

                // Remove qualquer caractere que não seja número (incluindo o '-')
                clientIdentifier = new string(clientIdentifier.Where(char.IsDigit).ToArray());

                // Buscar o cliente pelo CPF ou CNPJ (verifica qual está disponível)
                List<Client> selectedClient = _clientService.GetClientByIdentifier(clientIdentifier);
                Client client = selectedClient[0];

                // Verifica se o CPF não é nulo antes de tentar formatar
                string cpfCnpj = null;

                if (!string.IsNullOrEmpty(client.Cpf)) // Verifica se o CPF existe
                {
                    cpfCnpj = Formatter.FormatCpf(client.Cpf);
                }
                else if (!string.IsNullOrEmpty(client.Cnpj)) // Caso CPF seja nulo, verifica se o CNPJ existe
                {
                    cpfCnpj = Formatter.FormatCnpj(client.Cnpj);
                }

                if (client != null)
                {
                    // Carrega os dados do cliente selecionado nos campos de entrada
                    txtName.Text = client.Name;
                    txtCpfCnpj.Text = cpfCnpj;
                    txtEmail.Text = client.Email;
                    txtPhone.Text = client.Phone;
                    txtZipCode.Text = client.Address?.ZipCode;
                    txtStreet.Text = client.Address?.Street;
                    txtNumber.Text = client.Address?.Number;
                    txtComplement.Text = client.Address?.Complement;
                    txtNeighborhood.Text = client.Address?.Neighborhood;
                    txtCity.Text = client.Address?.City;
                    txtState.Text = client.Address?.State;

                    // Salva o ID do cliente para edição ou exclusão futura
                    ClientIdSave = client.Id;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ClientIdSave == 0)
            {
                MessageBox.Show("Faça uma busca antes de deletar o cliente!");
            }

            int clientId = ClientIdSave;

            var success = _clientService.DeleteClient(clientId);

            if (success)
            {
                MessageBox.Show("Cliente removido com sucesso.");
                ClientIdSave = 0;
            }
            else if(!success &&  ClientIdSave != 0) {
                MessageBox.Show("Erro ao remover cliente.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Remove espaço no começo e no final
            string cpfCnpj = txtCpfCnpj.Text.Trim();

            // Remove qualquer caractere que não seja número
            cpfCnpj = new string(cpfCnpj.Where(char.IsDigit).ToArray());

            if (ClientIdSave == 0)
            {
                MessageBox.Show("Faça uma busca antes de atualizar o cliente!");
            }

            Client clientToUpdate = new Client
            {
                Id = ClientIdSave,
                Name = txtName.Text,
                Cpf = cpfCnpj.Length == 11 ? cpfCnpj : null,
                Cnpj = cpfCnpj.Length == 14 ? cpfCnpj : null,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = new Address
                {
                    ZipCode = txtZipCode.Text,
                    Street = txtStreet.Text,
                    Number = txtNumber.Text,
                    Complement = txtComplement.Text,
                    Neighborhood = txtNeighborhood.Text,
                    City = txtCity.Text,
                    State = txtState.Text
                }
            };

            // Chama o serviço para atualizar o cliente
            var success = _clientService.UpdateClient(clientToUpdate);

            if (success)
            {
                MessageBox.Show("Cliente atualizado com sucesso.");
                ClearFields(); // Limpar os campos após a atualização
                ClientIdSave = 0;
            }
            else if(!success && ClientIdSave != 0) {
                MessageBox.Show("Erro ao atualizar cliente.");
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Form currentForm = this; // Ou outro formulário atual se necessário
            Form newForm = new FormProduct(); // Cria uma nova instância de FormProduct

            FormManager.SwitchForm(currentForm, newForm);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Form currentForm = this; // Ou outro formulário atual se necessário
            Form newForm = new FormOrder(); // Cria uma nova instância de FormOrder

            FormManager.SwitchForm(currentForm, newForm);
        }

        private async void txtZipCode_TextChanged(object sender, EventArgs e)
        {
            //Remove espaço no começo e no final
            string zipCode = txtZipCode.Text.Trim();

            // Remove qualquer caractere que não seja número (incluindo o '-')
            zipCode = new string(zipCode.Where(char.IsDigit).ToArray());

            // Verifica se o CEP tem o tamanho correto (8 dígitos)
            if (zipCode.Length == 8)
            {
                try
                {
                    // Chama o Service para buscar os dados do CEP
                    CepResponse cepResponse = await _cepService.ConsultCepAsync(zipCode);

                    // Preenche os campos com os dados do CEP
                    txtZipCode.Text = cepResponse.Cep;
                    txtStreet.Text = cepResponse.Logradouro;
                    txtNeighborhood.Text = cepResponse.Bairro;
                    txtCity.Text = cepResponse.Localidade;
                    txtState.Text = cepResponse.Uf;
                }
                catch (Exception ex)
                {
                    // Caso haja erro, exibe uma mensagem de erro para o usuário
                    MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (zipCode.Length == 0)
            {
                txtStreet.Text = string.Empty;
                txtNeighborhood.Text = string.Empty;
                txtCity.Text = string.Empty;
                txtState.Text = string.Empty;
            }
        }
    }
}
