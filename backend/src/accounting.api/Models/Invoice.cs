namespace Accounting.Api;

public class Invoice
{
    public int Id { get; set; }
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public InvoiceStatus Status { get; set; }
}

public enum InvoiceStatus
{
    Draft,
    Pending,
    Paid,
    Cancelled
}
