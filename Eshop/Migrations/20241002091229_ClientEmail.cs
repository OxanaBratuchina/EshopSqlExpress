using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eshop.Migrations
{
    /// <inheritdoc />
    public partial class ClientEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d38d10b-d688-4dc5-8d2f-94938c8f801a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4722703-b8b7-4873-9c56-e975d0b16242");

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Order",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientEmail",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a628427-ce98-4d6a-904e-0c209fd130b7", null, "User", "USER" },
                    { "b0d5af07-39db-4653-870f-12a7dcd2df37", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Count", "Price" },
                values: new object[] { 97.5, 8897.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Count", "Price" },
                values: new object[] { 9.0, 8122.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Count", "Price" },
                values: new object[] { 48.5, 3435.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Count", "Price" },
                values: new object[] { 41.0, 2294.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Count", "Price" },
                values: new object[] { 41.5, 9907.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Count", "Price" },
                values: new object[] { 25.0, 4316.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Count", "Price" },
                values: new object[] { 17.5, 4608.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Count", "Price" },
                values: new object[] { 102.0, 7523.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Count", "Price" },
                values: new object[] { 9.5, 5149.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Count", "Price" },
                values: new object[] { 83.0, 9764.9899999999998 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a628427-ce98-4d6a-904e-0c209fd130b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0d5af07-39db-4653-870f-12a7dcd2df37");

            migrationBuilder.DropColumn(
                name: "ClientEmail",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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
    }
}
