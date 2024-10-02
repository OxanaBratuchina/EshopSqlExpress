using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eshop.Migrations
{
    /// <inheritdoc />
    public partial class ClientComplexType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a628427-ce98-4d6a-904e-0c209fd130b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0d5af07-39db-4653-870f-12a7dcd2df37");

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ClientPhone",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27a51c7b-afb6-44fb-936e-782a3c05802f", null, "User", "USER" },
                    { "56a6762f-4bbd-47bb-94dc-617c24c10bc0", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Count", "Price" },
                values: new object[] { 11.5, 7969.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Count", "Price" },
                values: new object[] { 70.0, 6188.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Count", "Price" },
                values: new object[] { 84.5, 3044.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Count", "Price" },
                values: new object[] { 28.0, 8560.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Count", "Price" },
                values: new object[] { 77.5, 9485.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Count", "Price" },
                values: new object[] { 36.0, 8205.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Count", "Price" },
                values: new object[] { 43.5, 7304.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Count", "Price" },
                values: new object[] { 28.0, 3609.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Count", "Price" },
                values: new object[] { 57.5, 117.98999999999999 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Count", "Price" },
                values: new object[] { 90.0, 3137.9899999999998 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27a51c7b-afb6-44fb-936e-782a3c05802f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56a6762f-4bbd-47bb-94dc-617c24c10bc0");

            migrationBuilder.DropColumn(
                name: "ClientPhone",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Order",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
