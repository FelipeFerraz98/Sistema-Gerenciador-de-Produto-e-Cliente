using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Services;
using GerenciadorProdutoECliente.Repositories;
using iTextSharp.text; // Importa classes para a criação de documentos PDF.
using iTextSharp.text.pdf; // Importa classes para escrever no PDF.
using System.IO;

namespace GerenciadorProdutoECliente.Utils
{
    // Classe que cria um relatório de pedido em PDF
    public class PDFOrderReport
    {
        // Propriedades para armazenar o pedido, o valor pago e o cliente
        private Order Order { get; set; }
        private decimal PaidAmount { get; set; }
        private Client client; // Cliente associado ao pedido
        private Document pdf; // Documento PDF que será gerado
        private PdfWriter writer; // Escritor de PDF que gera o arquivo

        // Construtor que recebe um pedido e o valor pago
        public PDFOrderReport(Order order, decimal paidAmount)
        {
            Order = order; // Atribui o pedido
            PaidAmount = paidAmount; // Atribui o valor pago
        }

        // Método que gera o relatório em PDF
        public void GenerateReport(string filePath)
        {
            // Obtém os dados do cliente através do serviço ClientService
            ClientService clientService = new ClientService(new ClientRepository()); // Usando injeção de dependência
            client = clientService.GetClientById(Order.ClientId); // Obtém o cliente com base no ID do pedido

            // Configuração do PDF
            pdf = new Document(PageSize.A4, 15, 15, 15, 20); // Define o tamanho do papel e as margens
            writer = PdfWriter.GetInstance(pdf, new FileStream(filePath, FileMode.Create)); // Cria o escritor do PDF
            pdf.Open(); // Abre o documento para inserção de conteúdo

            // Adiciona o conteúdo ao PDF chamando métodos privados para cada seção
            AddTitle(); // Adiciona o título
            AddClientInfo(); // Adiciona as informações do cliente
            AddProducts(); // Adiciona os produtos do pedido
            AddSummary(); // Adiciona o resumo com total, valor pago e troco

            pdf.Close(); // Fecha o documento PDF
            writer.Close(); // Fecha o escritor
        }

        // Método que adiciona o título do relatório ao PDF
        private void AddTitle()
        {
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false); // Define a fonte base
            Font titleFont = new Font(baseFont, 32, Font.NORMAL, BaseColor.Black); // Define a fonte do título
            // Cria o título e o adiciona ao documento
            Paragraph title = new Paragraph($"Invoice #{Order.Id}\n\n", titleFont)
            {
                Alignment = Element.ALIGN_CENTER, // Alinha o título no centro
                SpacingAfter = 4 // Define um espaçamento após o título
            };
            pdf.Add(title); // Adiciona o título ao PDF
        }

        // Método que adiciona as informações do cliente ao PDF
        private void AddClientInfo()
        {
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false); // Define a fonte base
            Font textFont = new Font(baseFont, 12, Font.NORMAL, BaseColor.Black); // Define a fonte para o texto

            // Verifica se o CPF não é nulo antes de tentar formatar
            string cpfCnpj = null;

            if (!string.IsNullOrEmpty(client.Cpf)) // Verifica se o CPF existe
            {
                cpfCnpj = Formatter.FormatCpf(client.Cpf);
            }
            else if (!string.IsNullOrEmpty(client.Cnpj)) // Caso CPF seja nulo, verifica se o CNPJ existe
            {
                cpfCnpj = Formatter.FormatCnpj(client.Cnpj);
            }

            string phone = Formatter.FormatPhone(client.Phone); // Formata o telefone do cliente

            string zipCode = Formatter.FormatZipCode(client.Address.ZipCode);

            // Cria um parágrafo com as informações do cliente e adiciona ao PDF
            Paragraph clientInfo = new Paragraph($"Cliente: {client.Name} Portador do CPF/CNPJ: {cpfCnpj}\n" +
                                           $"Endereço: {client.Address.Street}, {client.Address.Number} -" +
                                           $" {client.Address.Neighborhood}\n {client.Address.City}" +
                                           $" - {client.Address.State} CEP {zipCode}\n" +
                                           $"Telefone: {phone}\n\n", textFont)
            {
                Alignment = Element.ALIGN_LEFT // Alinha o texto à esquerda
            };
            pdf.Add(clientInfo); // Adiciona as informações do cliente ao PDF
        }

        // Método que adiciona os produtos do pedido ao PDF
        private void AddProducts()
        {
            // Instancia o serviço de produtos e cria uma tabela para exibição
            ProductService productService = new ProductService(new ProductRepository());
            PdfPTable table = new PdfPTable(4); // Tabela com 4 colunas
            float[] widths = { 2f, 1f, 1f, 1f }; // Define a largura das colunas
            table.SetWidths(widths); // Aplica as larguras
            table.DefaultCell.BorderWidth = 0; // Remove a borda das células
            table.WidthPercentage = 100; // Define a largura da tabela em relação ao PDF

            // Adiciona os cabeçalhos da tabela
            CreateTextCell(table, "Produto", PdfPCell.ALIGN_LEFT, true);
            CreateTextCell(table, "Quantidade", PdfPCell.ALIGN_CENTER, true);
            CreateTextCell(table, "Preço Unitário", PdfPCell.ALIGN_RIGHT, true);
            CreateTextCell(table, "Total", PdfPCell.ALIGN_RIGHT, true);

            // Adiciona os itens do pedido à tabela
            foreach (OrderItem item in Order.OrderItems)
            {
                // Obtém o produto a partir do ID do produto no pedido
                Product product = productService.GetProductById(item.ProductId);
                if (product != null)
                {
                    // Adiciona as células com os dados do produto
                    CreateTextCell(table, product.Name); // Nome do produto
                    CreateTextCell(table, item.Quantity.ToString(), PdfPCell.ALIGN_CENTER); // Quantidade 
                    CreateTextCell(table, ConvertCurrency.ConvertToReal(item.UnitPrice), PdfPCell.ALIGN_RIGHT); // Preço unitário formatado
                    CreateTextCell(table, (ConvertCurrency.ConvertToReal(item.Quantity * item.UnitPrice)), PdfPCell.ALIGN_RIGHT); // Total formatado
                }
                else
                {
                    // Caso o produto não seja encontrado, exibe uma mensagem
                    CreateTextCell(table, "Produto não encontrado", PdfPCell.ALIGN_LEFT);
                    CreateTextCell(table, item.Quantity.ToString(), PdfPCell.ALIGN_CENTER);
                    CreateTextCell(table, ConvertCurrency.ConvertToReal(item.UnitPrice), PdfPCell.ALIGN_RIGHT);
                    CreateTextCell(table, (ConvertCurrency.ConvertToReal(item.Quantity * item.UnitPrice)), PdfPCell.ALIGN_RIGHT);
                }
            }

            pdf.Add(table); // Adiciona a tabela de produtos ao PDF
        }

        // Método que adiciona o resumo do pedido ao PDF
        private void AddSummary()
        {
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false); // Define a fonte base
            Font textFont = new Font(baseFont, 12, Font.NORMAL, BaseColor.Black); // Define a fonte para o texto

            // Converte os valores para o formato de Real (R$)
            string totalAmount = ConvertCurrency.ConvertToReal(Order.TotalAmount);
            string amountPaid = ConvertCurrency.ConvertToReal(PaidAmount);
            string change = "0"; // Para todo caso do valor pago ser igual ou menor

            if (PaidAmount >= Order.TotalAmount) // Se o valor pago for maior que o a pagar
            {
                change = ConvertCurrency.ConvertToReal(PaidAmount - Order.TotalAmount); // Calcula o troco e converte para Real
            }

            // Cria o parágrafo com o resumo do pedido (total, valor pago e troco)
            Paragraph summary = new Paragraph($"\nTotal do Pedido: {totalAmount:C2}\n" +
                                        $"Valor Pago: {amountPaid:C2}\n" +
                                        $"Troco: {change:C2}\n\n", textFont)
            {
                Alignment = Element.ALIGN_LEFT // Alinha o texto à esquerda
            };
            pdf.Add(summary); // Adiciona o resumo ao PDF
        }

        // Método que cria uma célula de texto para a tabela
        private void CreateTextCell(PdfPTable table, string text, int alignment = PdfPCell.ALIGN_LEFT, bool bold = false)
        {
            int style = Font.NORMAL; // Define o estilo da fonte como normal
            if (bold)
            {
                style = Font.BOLD; // Se o parâmetro bold for verdadeiro, a fonte será em negrito
            }

            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false); // Define a fonte base
            Font font = new Font(baseFont, 12, style, BaseColor.Black); // Define a fonte para o texto

            // Define a cor de fundo alternada para as células (linha ímpar terá fundo cinza claro)
            BaseColor backgroundColor = (table.Rows.Count % 2 == 1) ? new BaseColor(0.95f, 0.95f, 0.95f) : BaseColor.White;

            // Cria a célula com o texto, alinhamento, borda e cor de fundo
            PdfPCell cell = new PdfPCell(new Phrase(text, font))
            {
                HorizontalAlignment = alignment, // Alinha horizontalmente
                VerticalAlignment = PdfPCell.ALIGN_MIDDLE, // Alinha verticalmente
                Border = 0, // Remove a borda
                BorderWidthBottom = 1, // Adiciona uma borda inferior
                PaddingBottom = 5, // Adiciona um padding na parte inferior
                FixedHeight = 25, // Define a altura fixa da célula
                BackgroundColor = backgroundColor // Define a cor de fundo alternada
            };
            table.AddCell(cell); // Adiciona a célula à tabela
        }
    }
}
