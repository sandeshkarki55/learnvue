using Accounting.Api.Models;

namespace Accounting.Api;

public class Invoice
{
    public int Id { get; set; }
    public int Number { get; set; }
    public required DateTime Date { get; set; }
    public required decimal Amount { get; set; }
    public required InvoiceStatus Status { get; set; }
    public required ICollection<InvoiceLine> InvoiceLines { get; set; } = [];
}

public enum InvoiceStatus
{
    Draft,
    Pending,
    Paid,
    Cancelled
}
