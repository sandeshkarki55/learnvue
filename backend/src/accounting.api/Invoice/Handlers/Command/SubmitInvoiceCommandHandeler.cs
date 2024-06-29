using MediatR;

namespace Accounting.Api.Invoice.Handlers.Command;

public class SubmitInvoiceCommand : IRequest<Unit>
{
    public required string Id { get; set; }
}

public class SubmitInvoiceCommandHandler(InvoiceDbContext invoiceDbContext) : IRequestHandler<SubmitInvoiceCommand, Unit>
{
    public async Task<Unit> Handle(SubmitInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await invoiceDbContext.Invoices.FindAsync(request.Id, cancellationToken);

        if (invoice == null)
        {
            throw new Exception("Invoice not found");
        }

        invoice.Status = Models.InvoiceStatus.Pending;

        await invoiceDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}