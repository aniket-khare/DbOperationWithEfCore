using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbOperationsWithEFCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class BookPriceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookPrices",
                columns: new[] { "Id", "Amount", "BookId", "CurrencyId" },
                values: new object[,]
                {
                    { 1, 3000, 233, 1 },
                    { 2, 2000, 234, 3 },
                    { 3, 5000, 235, 4 },
                    { 4, 600, 236, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookPrices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookPrices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookPrices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookPrices",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
