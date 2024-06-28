using System.Linq.Expressions;
using Accounting.Api.Invoice.Dtos;

namespace Accounting.Api.Invoice;
public static class InvoiceMappings
{
    //Invoice ==> GetInvoiceDto
    public static Expression<Func<Models.Invoice, GetInvoiceDto>> ToGetInvoiceDto => invoice => new GetInvoiceDto
    {
        Id = invoice.Id,
        Number = invoice.Number,
        Date = invoice.Date.ToString("yyyy-MM-dd"),
        Amount = invoice.Amount,
        Status = invoice.Status.ToString()
    };
    public static Func<Models.Invoice, GetInvoiceDto> ToGetInvoiceDtoFunc = ToGetInvoiceDto.Compile();

    //CreateInvoiceDto ==> Invoice
    public static Func<CreateInvoiceDto.CreateInvoiceLinesDto, Models.InvoiceLine> ToInvoiceLineFunc = createInvoiceLinesDto => new Models.InvoiceLine
    {
        Description = createInvoiceLinesDto.Description,
        Quantity = createInvoiceLinesDto.Quantity,
        Price = createInvoiceLinesDto.Price
    };

    public static Func<CreateInvoiceDto, Models.Invoice> ToInvoiceFunc = createInvoiceDto => new Models.Invoice
    {
        Date = createInvoiceDto.Date,
        Amount = createInvoiceDto.Amount,
        Status = Models.InvoiceStatus.Draft,
        InvoiceLines = createInvoiceDto.InvoiceLines.Select(ToInvoiceLineFunc).ToList()
    };
}