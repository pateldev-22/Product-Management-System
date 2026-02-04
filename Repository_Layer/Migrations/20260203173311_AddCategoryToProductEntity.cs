using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository_Layer.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Electronics", new DateTime(2026, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Laptop", 999.99m, 10 },
                    { 2, "Electronics", new DateTime(2026, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Mouse", 29.99m, 50 },
                    { 3, "Furniture", new DateTime(2026, 2, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Office Chair", 199.99m, 25 }
                });
        }
    }
}
