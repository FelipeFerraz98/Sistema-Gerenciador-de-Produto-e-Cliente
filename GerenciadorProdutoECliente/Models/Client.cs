using System;
using GerenciadorProdutoECliente.Enums;

namespace GerenciadorProdutoECliente.Models
{
    // A classe 'Client' representa um cliente do sistema. Ela possui várias propriedades e comportamentos 
    // que permitem armazenar e manipular informações de um cliente, como nome, CPF, CNPJ, entre outros.
    public class Client
    {
        // Propriedade que armazena o ID único do cliente (gerado automaticamente pelo banco de dados).
        public int Id { get; set; }

        // Propriedade que armazena o nome do cliente.
        public string Name { get; set; }

        // Propriedade que armazena o CPF do cliente (campo opcional, com 11 caracteres). 
        public string Cpf { get; set; }

        // Propriedade que armazena o CNPJ do cliente (campo opcional, com 14 caracteres).
        public string Cnpj { get; set; }

        // Propriedade que armazena o e-mail do cliente.
        public string Email { get; set; }

        // Propriedade que armazena o tipo de cliente (Pessoa Física ou Pessoa Jurídica).
        public ClientType ClientType { get; set; }

        // Propriedade que armazena o telefones do cliente.
        public string Phone { get; set; }

        // Propriedade que armazena o endereço associado ao cliente.
        public Address Address { get; set; }


        // Construtor padrão da classe, necessário para criar uma instância do cliente sem fornecer dados inicialmente.
        public Client()
        {
            // Inicializa Endereco
            Address = new Address();
        }

        // Construtor que recebe dados específicos para criar um cliente.
        public Client(int id, string name, string cpf, string cnpj, string email, ClientType clientType)
        {
            // Atribui os dados recebidos ao cliente
            Id = id;
            Name = name;
            Cpf = cpf;
            Cnpj = cnpj;
            Email = email;
            ClientType = clientType;

            // Inicializa Endereco
            Address = new Address();
        }

        // Método para validar se o CPF ou CNPJ estão corretos, de acordo com o tipo de cliente.
        // Esse método garante que, para um cliente do tipo "Pessoa Física", o CPF deve ser fornecido e o CNPJ não.
        // E para um cliente do tipo "Pessoa Jurídica", o CNPJ deve ser fornecido e o CPF não deve ser fornecido.
        public void ValidateCpfOrCnpj()
        {
            // Se o cliente for do tipo "Pessoa Física", o CPF deve ser fornecido
            if (ClientType == ClientType.Individual)
            {
                // Verifica se o CPF é válido (deve ter 11 caracteres)
                if (string.IsNullOrEmpty(Cpf) || Cpf.Length != 11)
                {
                    throw new ArgumentException("O CPF deve ser fornecido para clientes do tipo Pessoa Física e deve ter 11 caracteres.");
                }
            }
            // Se o cliente for do tipo "Pessoa Jurídica", o CNPJ deve ser fornecido
            else if (ClientType == ClientType.LegalEntity)
            {
                // Verifica se o CNPJ é válido (deve ter 14 caracteres)
                if (string.IsNullOrEmpty(Cnpj) || Cnpj.Length != 14)
                {
                    throw new ArgumentException("O CNPJ deve ser fornecido para clientes do tipo Pessoa Jurídica e deve ter 14 caracteres.");
                }
            }
            else
            {
                throw new ArgumentException("Tipo de cliente inválido.");
            }
        }
    }
}