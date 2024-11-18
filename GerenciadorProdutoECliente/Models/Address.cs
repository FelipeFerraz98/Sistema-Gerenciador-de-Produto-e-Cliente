namespace GerenciadorProdutoECliente.Models
{
    // A classe 'Address' representa o endereço de um cliente
    public class Address
    {
        // Propriedade que armazena o ID único do endereço
        public int Id { get; set; }

        // Propriedade que armazena o CEP do endereço
        public string ZipCode { get; set; }

        // Propriedade que armazena o nome da rua do endereço
        public string Street { get; set; }

        // Propriedade que armazena o número da residencia
        public string Number { get; set; }

        // Propriedade para armazenar um complemento do endereço (exemplo: "Apto 101", "Bloco A")
        public string Complement { get; set; }

        // Propriedade que armazena o bairro onde o endereço está localizado
        public string Neighborhood { get; set; }

        // Propriedade que armazena o nome da cidade onde o endereço está localizado
        public string City { get; set; }

        // Propriedade que armazena a unidade federativa (UF)
        public string State { get; set; }

        // Propriedade que armazena o ID do cliente ao qual este endereço pertence
        public int ClientId { get; set; }

        // Construtor padrão, necessário para criar uma instância da classe sem inicializar as propriedades
        public Address() { }

        // Construtor que recebe todos os dados do endereço, permitindo criar um novo endereço completo
        public Address(int id, string zipCode, string street, string number, string complement, string neighborhood, string city, string state, int clientId)
        {
            Id = id;                 // Atribui o ID único do endereço
            ZipCode = zipCode;       // Atribui o CEP do endereço
            Street = street;         // Atribui o nome da rua
            Number = number;         // Atribui o número do imóvel
            Complement = complement; // Atribui o complemento do endereço, se houver
            Neighborhood = neighborhood; // Atribui o bairro do endereço
            City = city;             // Atribui a cidade onde o endereço está localizado
            State = state;           // Atribui o estado (UF) do endereço
            ClientId = clientId;     // Atribui o ID do cliente, que é dono desse endereço
        }
    }
}