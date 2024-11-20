using Newtonsoft.Json;

namespace GerenciadorProdutoECliente.Models
{
    public class CepResponse
    {
        // O CEP que foi consultado
        [JsonProperty("cep")]
        public string Cep { get; set; }

        // Logradouro (Rua)
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        // Bairro
        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        // Localidade (Cidade)
        [JsonProperty("localidade")]
        public string Localidade { get; set; }

        // UF (Estado)
        [JsonProperty("uf")]
        public string Uf { get; set; }
    }
}
