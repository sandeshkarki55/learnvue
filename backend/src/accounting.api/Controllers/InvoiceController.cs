using Accounting.Api;
using Accounting.Api.Dtos.Invoice;
using Accounting.Api.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetInvoices()
    {
        List<Invoice> invoices = [
            new Invoice
            {
                Id = 1,
                Number = 1001,
                Date = DateTime.Now,
                Amount = 100.00m,
                Status = InvoiceStatus.Paid,
                InvoiceLines =[]
            },
            new Invoice
            {
                Id = 2,
                Number = 1002,
                Date = DateTime.Now,
                Amount = 200.00m,
                Status = InvoiceStatus.Pending,
                InvoiceLines =[]
            },
            new Invoice
            {
                Id = 3,
                Number = 1003,
                Date = DateTime.Now,
                Amount = 300.00m,
                Status = InvoiceStatus.Draft,
                InvoiceLines =[]
            },
            new Invoice
            {
                Id = 4,
                Number = 1004,
                Date = DateTime.Now,
                Amount = 400.00m,
                Status = InvoiceStatus.Cancelled,
                InvoiceLines =[]
            }
        ];

        return Ok(invoices.Select(InvoiceMappings.ToGetInvoiceDtoFunc));

    }

    [HttpPost]
    public async Task<IActionResult> CreateInvoice(CreateInvoiceDto createInvoiceDto)
    {
        var invoice = InvoiceMappings.ToInvoiceFunc(createInvoiceDto);

        return Ok(invoice);
    }
}
