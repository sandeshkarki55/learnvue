using Accounting.Api;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetInvoices()
    {
        return Ok(new List<Invoice>
        {
            new Invoice
            {
                Id = 1,
                Number = 1001,
                Date = DateTime.Now,
                Amount = 100.00m,
                Status = InvoiceStatus.Paid
            },
            new Invoice
            {
                Id = 2,
                Number = 1002,
                Date = DateTime.Now,
                Amount = 200.00m,
                Status = InvoiceStatus.Pending
            },
            new Invoice
            {
                Id = 3,
                Number = 1003,
                Date = DateTime.Now,
                Amount = 300.00m,
                Status = InvoiceStatus.Draft
            },
            new Invoice
            {
                Id = 4,
                Number = 1004,
                Date = DateTime.Now,
                Amount = 400.00m,
                Status = InvoiceStatus.Cancelled
            }
        });
    }
}
