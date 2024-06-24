namespace Accounting.Api.Models
{
    public class InvoiceLine
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}