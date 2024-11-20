using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Repositories;
using System.Threading.Tasks;

namespace GerenciadorProdutoECliente.Services
{
    public class CepService
    {
        private readonly CepRepository _cepRepository;

        public CepService()
        {
            _cepRepository = new CepRepository(); // Inicializa o Repository
        }

        // Método para consultar o CEP e retornar os dados do endereço
        public async Task<CepResponse> ConsultCepAsync(string cep)
        {
            return await _cepRepository.GetCepAsync(cep); // Chama o Repository para pegar os dados
        }
    }
}
