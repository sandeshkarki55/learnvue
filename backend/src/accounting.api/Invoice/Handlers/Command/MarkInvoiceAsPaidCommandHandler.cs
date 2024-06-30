using Accounting.Api.Invoice.Models;
using MediatR;

namespace Accounting.Api.Invoice.Handlers.Command
{
    public class MarkInvoiceAsPaidCommand : IRequest<Unit>
    {
        public required string Id { get; set; }
    }

    public class MarkInvoiceAsPaidCommandHandler(InvoiceDbContext invoiceDbContext) : IRequestHandler<MarkInvoiceAsPaidCommand, Unit>
    {
        public async Task<Unit> Handle(MarkInvoiceAsPaidCommand request, CancellationToken cancellationToken)
        {
            var invoice = await invoiceDbContext.Invoices.FindAsync(request.Id);

            if (invoice == null)
            {
                throw new Exception("Invoice not found");
            }

            invoice.Status = InvoiceStatus.Paid;

            await invoiceDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}