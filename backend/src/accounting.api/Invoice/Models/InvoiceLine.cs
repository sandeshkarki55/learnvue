
using Accounting.Api.Common;

namespace Accounting.Api.Invoice.Models;

public class InvoiceLine : BaseEntity
{
    public required string Description { get; set; }
    public required int Quantity { get; set; }
    public required decimal Price { get; set; }
    public string InvoiceId { get; set; }
}