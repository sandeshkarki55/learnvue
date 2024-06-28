using Accounting.Api.Invoice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace accounting.api.Invoice.Data.Configurations;

public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
{
    public void Configure(EntityTypeBuilder<InvoiceLine> builder)
    {
        builder.HasKey(il => il.Id);
        builder.Property(il => il.Description).IsRequired();
        builder.Property(il => il.Quantity).IsRequired();
        builder.Property(il => il.Price).HasPrecision(18, 2).IsRequired();
        builder.Property(il => il.InvoiceId).IsRequired();
    }
}
