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
    }
}