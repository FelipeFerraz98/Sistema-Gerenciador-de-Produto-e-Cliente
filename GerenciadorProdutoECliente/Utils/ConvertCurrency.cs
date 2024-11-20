using System.Globalization;

namespace GerenciadorProdutoECliente.Utils
{
    public static class ConvertCurrency
    {
        public static string ConvertToReal(decimal currency)
        {
            return currency.ToString("C2", new CultureInfo("pt-BR"));
        }
    }
}
