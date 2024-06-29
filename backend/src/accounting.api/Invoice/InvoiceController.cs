using Accounting.Api.Invoice.Dtos;
using Accounting.Api.Invoice.Handlers.Command;
using Accounting.Api.Invoice.Handlers.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Api.Invoice;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetInvoices()
    {
        var invoices = await mediator.Send(new GetInvoicesQuery());

        return Ok(invoices);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInvoice([FromQuery] string id)
    {
        var invoice = await mediator.Send(new GetInvoiceQuery { Id = id });

        return Ok(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand createInvoiceCommand)
    {
        var invoice = await mediator.Send(createInvoiceCommand);
        return Ok(invoice);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoice([FromRoute] string id)
    {
        await mediator.Send(new DeleteInvoiceCommand { Id = id });

        return NoContent();
    }

    [HttpPut("{id}/submit")]
    public async Task<IActionResult> SubmitInvoice([FromRoute] string id)
    {
        var invoice = await mediator.Send(new SubmitInvoiceCommand { Id = id });

        return Ok(invoice);
    }
}
