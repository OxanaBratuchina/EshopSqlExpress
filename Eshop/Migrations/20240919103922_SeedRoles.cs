using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eshop.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d38d10b-d688-4dc5-8d2f-94938c8f801a", null, "Admin", "ADMIN" },
                    { "d4722703-b8b7-4873-9c56-e975d0b16242", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Count", "Price" },
                values: new object[] { 33.5, 209.99000000000001 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Count", "Price" },
                values: new object[] { 79.0, 5272.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Count", "Price" },
                values: new object[] { 64.5, 8241.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Count", "Price" },
                values: new object[] { 23.0, 4098.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Count", "Price" },
                values: new object[] { 14.5, 8319.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Count", "Price" },
                values: new object[] { 9.0, 7421.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Count", "Price" },
                values: new object[] { 28.5, 3312.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Count", "Price" },
                values: new object[] { 80.0, 2343.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Count", "Price" },
                values: new object[] { 50.5, 6068.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Count", "Price" },
                values: new object[] { 81.0, 8871.9899999999998 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d38d10b-d688-4dc5-8d2f-94938c8f801a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4722703-b8b7-4873-9c56-e975d0b16242");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Count", "Price" },
                values: new object[] { 96.5, 8666.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Count", "Price" },
                values: new object[] { 32.0, 3861.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Count", "Price" },
                values: new object[] { 24.5, 7797.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Count", "Price" },
                values: new object[] { 89.0, 2488.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Count", "Price" },
                values: new object[] { 36.5, 9080.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Count", "Price" },
                values: new object[] { 84.0, 1502.99 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Count", "Price" },
                values: new object[] { 7.5, 8989.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Count", "Price" },
                values: new object[] { 72.0, 5308.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Count", "Price" },
                values: new object[] { 33.5, 1731.99 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Count", "Price" },
                values: new object[] { 77.0, 1415.99 });
        }
    }
}
