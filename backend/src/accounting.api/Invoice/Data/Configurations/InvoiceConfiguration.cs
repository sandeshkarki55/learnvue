using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounting.Api.Invoice.Data.Configurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Models.Invoice>
{
    public void Configure(EntityTypeBuilder<Models.Invoice> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Number).IsRequired()
            .HasDefaultValueSql("NEXT VALUE FOR InvoiceNumbers"); ;
        builder.Property(i => i.Date).IsRequired();
        builder.Property(i => i.Amount).HasPrecision(18, 2).IsRequired();
        builder.Property(i => i.Status).IsRequired();
        builder
            .HasMany(i => i.InvoiceLines)
            .WithOne()
            .HasForeignKey(il => il.InvoiceId);
    }
}
