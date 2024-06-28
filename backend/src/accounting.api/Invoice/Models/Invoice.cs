using Accounting.Api.Common;

namespace Accounting.Api.Invoice.Models;

public class Invoice : BaseEntity
{
    public int Number { get; set; }
    public required DateTime Date { get; set; }
    public required decimal Amount { get; set; }
    public required InvoiceStatus Status { get; set; }
    public required ICollection<InvoiceLine> InvoiceLines { get; set; } = [];
}
