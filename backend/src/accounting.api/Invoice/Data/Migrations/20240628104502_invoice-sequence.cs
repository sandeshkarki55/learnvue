using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace accounting.api.Invoice.Data.Migrations
{
    /// <inheritdoc />
    public partial class invoicesequence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "InvoiceNumbers");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR InvoiceNumbers",
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "InvoiceNumbers");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Invoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR InvoiceNumbers");
        }
    }
}
