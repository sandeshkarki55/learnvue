namespace Accounting.Api.Invoice.Dtos;
public class CreateInvoiceDto
{
    public required DateTime Date { get; set; }
    public required decimal Amount { get; set; }
    public required CreateInvoiceLinesDto[] InvoiceLines { get; set; } = [];

    public class CreateInvoiceLinesDto
    {
        public required string Description { get; set; }
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
    }
}