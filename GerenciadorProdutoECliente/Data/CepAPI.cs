using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GerenciadorProdutoECliente.Data
{
    public class CepAPI
    {
        private static readonly HttpClient client = new HttpClient();

        // Método para fazer a requisição à API ViaCEP
        public async Task<string> GetCepDataAsync(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            // Envia a requisição GET para a API
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                // Lê a resposta e retorna como string JSON
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Caso haja um erro na resposta, lança uma exceção
                throw new Exception("Error fetching data from ViaCEP.");
            }
        }
    }
}
