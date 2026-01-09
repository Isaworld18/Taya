using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taya_Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Movements",
            columns: new[] { "Id", "OperationDate", "ValueDate", "Amount", "Description", "Category" },
            values: new object[,]
            {
                { Guid.NewGuid(), DateTime.Now, DateTime.Now, 100.50, "Work income", "Payment" },
                { Guid.NewGuid(), DateTime.Now, DateTime.Now, 100.50, "Work income", "Payment" },
                { Guid.NewGuid(), DateTime.Now, DateTime.Now, -50.50, "Taxis", "Movement" },
                { Guid.NewGuid(), DateTime.Now, DateTime.Now, 100.50, "Work income", "Payment" },
                { Guid.NewGuid(), DateTime.Now, DateTime.Now, -1500.50, "Taxes", "Bugets" }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
