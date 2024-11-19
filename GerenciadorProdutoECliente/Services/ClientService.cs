using System;
using System.Collections.Generic;
using GerenciadorProdutoECliente.Enums;
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
        public List<Client> GetClientByIdentifier(string identifier)
        {
            try
            {
                // Verifica se o identificador está vazio
                if (string.IsNullOrWhiteSpace(identifier))
                {
                    Console.WriteLine("O identificador não pode ser vazio.");
                    return null;
                }

                // Chama o método do repositório para buscar o cliente
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

        // Método para validar CPF ou CNPJ
        public bool ValidateCpfOrCnpj(string cpfCnpj, ClientType clientType)
        {
            // Validação do CPF ou CNPJ conforme o tipo de cliente
            if (clientType == ClientType.Individual)
            {
                // Valida CPF
                if (string.IsNullOrEmpty(cpfCnpj) || cpfCnpj.Length != 11 || !IsValidCpf(cpfCnpj))
                {
                    return false;
                }
            }
            else if (clientType == ClientType.LegalEntity)
            {
                // Valida CNPJ
                if (string.IsNullOrEmpty(cpfCnpj) || cpfCnpj.Length != 14 || !IsValidCnpj(cpfCnpj))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        // Função de validação de CPF
        private bool IsValidCpf(string cpf)
        {
            return true;
        }

        // Função de validação de CNPJ
        private bool IsValidCnpj(string cnpj)
        {
            return true; 
        }
    }
}
