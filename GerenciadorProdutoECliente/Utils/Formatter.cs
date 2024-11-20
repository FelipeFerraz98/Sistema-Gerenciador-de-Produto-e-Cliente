using System;

namespace GerenciadorProdutoECliente.Utils
{
    public static class Formatter
    {
        // Método para formatar CPF
        public static string FormatCpf(string cpf)
        {
            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }

        // Método para formatar CNPJ
        public static string FormatCnpj(string cnpj)
        {
            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }

        // Método para formatar Telefone (fixo ou móvel)
        public static string FormatPhone(string phone)
        {
            if (phone.Length == 11)
            {
                // Formato para celular (11 dígitos): (11) 97552-2976
                return $"({phone.Substring(0, 2)}) {phone.Substring(2, 5)}-{phone.Substring(7, 4)}";
            }
            else
            {
                // Formato para fixo (10 dígitos): (11) 4552-2976
                return $"({phone.Substring(0, 2)}) {phone.Substring(2, 4)}-{phone.Substring(6, 4)}";
            }
        }

        // Método para formatar CEP
        public static string FormatZipCode(string zipCode)
        {
            // Formata o CEP para o padrão XXXXX-XXX
            return $"{zipCode.Substring(0, 5)}-{zipCode.Substring(5, 3)}";
        }
    }
}
