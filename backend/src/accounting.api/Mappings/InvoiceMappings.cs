using System.Linq.Expressions;
using Accounting.Api.Dtos.Invoice;
using Accounting.Api.Models;

namespace Accounting.Api.Mappings;
public static class InvoiceMappings
{
    //Invoice ==> GetInvoiceDto
    public static Expression<Func<Invoice, GetInvoiceDto>> ToGetInvoiceDto => invoice => new GetInvoiceDto
    {
        Id = invoice.Id,
        Number = invoice.Number,
        Date = invoice.Date.ToString("yyyy-MM-dd"),
        Amount = invoice.Amount,
        Status = invoice.Status.ToString()
    };
    public static Func<Invoice, GetInvoiceDto> ToGetInvoiceDtoFunc = ToGetInvoiceDto.Compile();

    //CreateInvoiceDto ==> Invoice
    public static Func<CreateInvoiceDto.CreateInvoiceLinesDto, InvoiceLine> ToInvoiceLineFunc = createInvoiceLinesDto => new InvoiceLine
    {
        Description = createInvoiceLinesDto.Description,
        Quantity = createInvoiceLinesDto.Quantity,
        Price = createInvoiceLinesDto.Price
    };

    public static Func<CreateInvoiceDto, Invoice> ToInvoiceFunc = createInvoiceDto => new Invoice
    {
        Date = createInvoiceDto.Date,
        Amount = createInvoiceDto.Amount,
        Status = InvoiceStatus.Draft,
        InvoiceLines = createInvoiceDto.InvoiceLines.Select(ToInvoiceLineFunc).ToList()
    };
}