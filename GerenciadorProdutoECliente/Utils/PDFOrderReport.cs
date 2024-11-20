using GerenciadorProdutoECliente.Models;
using GerenciadorProdutoECliente.Services;
using GerenciadorProdutoECliente.Repositories;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace GerenciadorProdutoECliente.Utils
{
    public class PDFOrderReport
    {
        private Order Order { get; set; }
        private decimal PaidAmount { get; set; }
        private Client client;
        private Document pdf;
        private PdfWriter writer;

        public PDFOrderReport(Order order, decimal paidAmount)
        {
            Order = order;
            PaidAmount = paidAmount;

        }

        public void GenerateReport(string filePath)
        {
            // Obter os dados do cliente através do OrderService e ClientService
            ClientService clientService = new ClientService(new ClientRepository()); // Ou injeção de dependência
            client = clientService.GetClientById(Order.ClientId);

            // Configuração do PDF
            pdf = new Document(PageSize.A4, 15, 15, 15, 20);
            writer = PdfWriter.GetInstance(pdf, new FileStream(filePath, FileMode.Create));
            pdf.Open();

            // Add content to the PDF
            AddTitle();
            AddClientInfo();
            AddProducts();
            AddSummary();

            pdf.Close();
            writer.Close();
        }

        private void AddTitle()
        {
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            Font titleFont = new Font(baseFont, 32, Font.NORMAL, BaseColor.Black);
            Paragraph title = new Paragraph($"Invoice #{Order.Id}\n\n", titleFont)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 4
            };
            pdf.Add(title);
        }

        private void AddClientInfo()
        {
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            Font textFont = new Font(baseFont, 12, Font.NORMAL, BaseColor.Black);

            string cpfCnpj = client.Cpf ?? client.Cnpj;

            Paragraph clientInfo = new Paragraph($"Cliente: {client.Name} Portador do CPF/CNPJ: {cpfCnpj}\n" +
                                           $"Endereço: {client.Address.Street}, {client.Address.Number}" +
                                           $" {client.Address.Neighborhood}, {client.Address.City} - {client.Address.State} - CEP {client.Address.ZipCode}\n" +
                                           $"Telefone: {client.Phone}\n\n", textFont)
            {
                Alignment = Element.ALIGN_LEFT
            };
            pdf.Add(clientInfo);
        }

        private void AddProducts()
        {
            ProductService productService = new ProductService(new ProductRepository());
            PdfPTable table = new PdfPTable(4);
            float[] widths = { 2f, 1f, 1f, 1f };
            table.SetWidths(widths);
            table.DefaultCell.BorderWidth = 0;
            table.WidthPercentage = 100;

            // Add column headers
            CreateTextCell(table, "Produto", PdfPCell.ALIGN_LEFT, true);
            CreateTextCell(table, "Quantidade", PdfPCell.ALIGN_CENTER, true);
            CreateTextCell(table, "Preço Unitário", PdfPCell.ALIGN_RIGHT, true);
            CreateTextCell(table, "Total", PdfPCell.ALIGN_RIGHT, true);

            // Add products (buscar o nome do produto através do ProductService)
            foreach (OrderItem item in Order.OrderItems)
            {
                Product product = productService.GetProductById(item.ProductId); // Obtém o produto pelo ProductId
                if (product != null)
                {
                    CreateTextCell(table, product.Name); // Nome do produto
                    CreateTextCell(table, ConvertCurrency.ConvertToReal(item.Quantity), PdfPCell.ALIGN_CENTER);
                    CreateTextCell(table, ConvertCurrency.ConvertToReal(item.UnitPrice), PdfPCell.ALIGN_RIGHT);
                    CreateTextCell(table, (ConvertCurrency.ConvertToReal(item.Quantity * item.UnitPrice)), PdfPCell.ALIGN_RIGHT);
                }
                else
                {
                    CreateTextCell(table, "Produto não encontrado", PdfPCell.ALIGN_LEFT);
                    CreateTextCell(table, ConvertCurrency.ConvertToReal(item.Quantity), PdfPCell.ALIGN_CENTER);
                    CreateTextCell(table, ConvertCurrency.ConvertToReal(item.UnitPrice), PdfPCell.ALIGN_RIGHT);
                    CreateTextCell(table, (ConvertCurrency.ConvertToReal(item.Quantity * item.UnitPrice)), PdfPCell.ALIGN_RIGHT);
                }
            }

            pdf.Add(table);
        }

        private void AddSummary()
        {
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            Font textFont = new Font(baseFont, 12, Font.NORMAL, BaseColor.Black);

            // Add summary with total, paid amount, and change
            string totalAmount = ConvertCurrency.ConvertToReal(Order.TotalAmount);
            string amountPaid = ConvertCurrency.ConvertToReal(PaidAmount);
            string change = ConvertCurrency.ConvertToReal(PaidAmount - Order.TotalAmount);

            Paragraph summary = new Paragraph($"\nTotal do Pedido: {totalAmount:C2}\n" +
                                        $"Valor Pago: {amountPaid:C2}\n" +
                                        $"Troco: {change:C2}\n\n", textFont)
            {
                Alignment = Element.ALIGN_LEFT
            };
            pdf.Add(summary);
        }

        private void CreateTextCell(PdfPTable table, string text, int alignment = PdfPCell.ALIGN_LEFT, bool bold = false)
        {
            int style = Font.NORMAL;
            if (bold)
            {
                style = Font.BOLD;
            }

            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            Font font = new Font(baseFont, 12, style, BaseColor.Black);

            BaseColor backgroundColor = (table.Rows.Count % 2 == 1) ? new BaseColor(0.95f, 0.95f, 0.95f) : BaseColor.White;

            PdfPCell cell = new PdfPCell(new Phrase(text, font))
            {
                HorizontalAlignment = alignment,
                VerticalAlignment = PdfPCell.ALIGN_MIDDLE,
                Border = 0,
                BorderWidthBottom = 1,
                PaddingBottom = 5,
                FixedHeight = 25,
                BackgroundColor = backgroundColor
            };
            table.AddCell(cell);
        }
    }
}
