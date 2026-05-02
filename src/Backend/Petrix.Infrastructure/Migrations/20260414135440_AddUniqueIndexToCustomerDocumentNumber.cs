using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Petrix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToCustomerDocumentNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_DocumentNumber",
                table: "Customers",
                column: "DocumentNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_DocumentNumber",
                table: "Customers");
        }
    }
}
