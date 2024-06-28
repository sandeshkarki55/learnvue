namespace Accounting.Api.Invoice.Dtos;

public class GetInvoiceDto
{
    public required string Id { get; set; }
    public required int Number { get; set; }
    public required string Date { get; set; }
    public required decimal Amount { get; set; }
    public required string Status { get; set; }
}
