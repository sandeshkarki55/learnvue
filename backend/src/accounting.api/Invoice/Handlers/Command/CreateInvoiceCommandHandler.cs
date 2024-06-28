using Accounting.Api.Invoice.Dtos;
using MediatR;

namespace Accounting.Api.Invoice.Handlers.Command;

public class CreateInvoiceCommand : CreateInvoiceDto, IRequest<GetInvoiceDto>
{
}

public class CreateInvoiceCommandHandler(InvoiceDbContext invoiceDbContext) : IRequestHandler<CreateInvoiceCommand, GetInvoiceDto>
{
    public async Task<GetInvoiceDto> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = InvoiceMappings.ToInvoiceFunc(request);

        await invoiceDbContext.Invoices.AddAsync(invoice, cancellationToken);
        await invoiceDbContext.SaveChangesAsync(cancellationToken);

        return InvoiceMappings.ToGetInvoiceDtoFunc(invoice);
    }
}