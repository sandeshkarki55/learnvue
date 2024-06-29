using MediatR;

namespace Accounting.Api.Invoice.Handlers.Command;

public class DeleteInvoiceCommand : IRequest<Unit>
{
    public required string Id { get; set; }
}

public class DeleteInvoiceCommandHandler(InvoiceDbContext dbContext) : IRequestHandler<DeleteInvoiceCommand, Unit>
{
    public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await dbContext.Invoices.FindAsync(request.Id, cancellationToken);

        dbContext.Invoices.Remove(invoice);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}