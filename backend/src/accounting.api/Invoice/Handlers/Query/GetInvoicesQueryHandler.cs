using Accounting.Api.Invoice.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Invoice.Handlers.Query;

public class GetInvoicesQuery : IRequest<IEnumerable<GetInvoiceDto>>
{
}


public class GetInvoicesQueryHandler(InvoiceDbContext invoiceDbContext) : IRequestHandler<GetInvoicesQuery, IEnumerable<GetInvoiceDto>>
{
    public async Task<IEnumerable<GetInvoiceDto>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
    {
        var invoices = await invoiceDbContext.Invoices
                            .Include(i => i.InvoiceLines)
                            .Select(InvoiceMappings.ToGetInvoiceDto)
                            .ToListAsync(cancellationToken);
        
        return invoices;
    }
}