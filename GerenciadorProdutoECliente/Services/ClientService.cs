using System;
using System.Collections.Generic;
using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Repositories;

namespace GerenciadorProdutoECliente.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // Método para adicionar um cliente
        public bool AddClient(Client client)
        {
            try
            {
                // Validação do cliente antes de adicionar
                if (client == null)
                {
                    Console.WriteLine("Dados do cliente são inválidos.");
                    return false;
                }

                // Validação de CPF ou CNPJ de acordo com o tipo de cliente
                client.ValidateCpfOrCnpj();

                // Chama o repositório para adicionar o cliente
                return _clientRepository.AddClient(client);
            }
            catch (ArgumentException ex)
            {
                // Trata erros de validação (CPF ou CNPJ inválido)
                Console.WriteLine($"Erro de validação: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Tratar erros genéricos
                Console.WriteLine($"Erro ao adicionar cliente: {ex.Message}");
                return false;
            }
        }

        // Método para buscar cliente por identificador (nome, CPF ou CNPJ)
        public Client GetClientByIdentifier(string identifier)
        {
            try
            {
                // Verifica se o identificador está vazio
                if (string.IsNullOrWhiteSpace(identifier))
                {
                    Console.WriteLine("O identificador não pode ser vazio.");
                    return null;
                }

                return _clientRepository.SearchByIdentifier(identifier);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar cliente pelo identificador: {ex.Message}");
                return null;
            }
        }

        // Método para atualizar cliente
        public bool UpdateClient(Client client)
        {
            try
            {
                // Validação do cliente atualizado
                if (client == null)
                {
                    Console.WriteLine("Dados atualizados são inválidos.");
                    return false;
                }

                // Validação de CPF ou CNPJ de acordo com o tipo de cliente
                client.ValidateCpfOrCnpj();

                return _clientRepository.UpdateClient(client);
            }
            catch (ArgumentException ex)
            {
                // Trata erros de validação (CPF ou CNPJ inválido)
                Console.WriteLine($"Erro de validação: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Tratar erros genéricos
                Console.WriteLine($"Erro ao atualizar cliente: {ex.Message}");
                return false;
            }
        }

        // Método para deletar cliente
        public bool DeleteClient(int clientId)
        {
            try
            {
                // Verifica se o identificador está vazio
                if (clientId == 0)
                {
                    Console.WriteLine("O identificador não pode ser vazio.");
                    return false;
                }

                return _clientRepository.DeleteClient(clientId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar cliente: {ex.Message}");
                return false;
            }
        }
    }
}
