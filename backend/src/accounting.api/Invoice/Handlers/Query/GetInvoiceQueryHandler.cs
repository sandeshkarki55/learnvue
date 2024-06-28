using Accounting.Api.Invoice.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Invoice.Handlers.Query;

public class GetInvoiceQuery : IRequest<GetInvoiceDto>
{
    public required string Id { get; set; }
}

public class GetInvoiceQueryHandler : IRequestHandler<GetInvoiceQuery, GetInvoiceDto>
{
    private readonly InvoiceDbContext _invoiceDbContext;

    public GetInvoiceQueryHandler(InvoiceDbContext invoiceDbContext)
    {
        _invoiceDbContext = invoiceDbContext;
    }

    public async Task<GetInvoiceDto> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceDbContext.Invoices
                            .Include(i => i.InvoiceLines)
                            .Select(InvoiceMappings.ToGetInvoiceDto)
                            .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

        return invoice;
    }
}
