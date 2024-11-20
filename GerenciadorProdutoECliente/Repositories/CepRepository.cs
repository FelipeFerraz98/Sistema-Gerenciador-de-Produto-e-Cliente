using GerenciadorProdutoECliente.Data;
using GerenciadorProdutoECliente.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GerenciadorProdutoECliente.Repositories
{
    public class CepRepository
    {
        private readonly CepAPI _cepAPI;

        public CepRepository()
        {
            _cepAPI = new CepAPI(); // Instancia a classe CepAPI para fazer a requisição
        }

        // Método para consultar o CEP
        public async Task<CepResponse> GetCepAsync(string cep)
        {
            try
            {
                // Faz a requisição à API ViaCEP
                string jsonResponse = await _cepAPI.GetCepDataAsync(cep);

                // Desserializa a resposta JSON para um objeto CepResponse
                return JsonConvert.DeserializeObject<CepResponse>(jsonResponse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching CEP data: {ex.Message}");
            }
        }
    }
}
