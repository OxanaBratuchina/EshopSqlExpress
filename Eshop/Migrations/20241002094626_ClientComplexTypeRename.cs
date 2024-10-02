using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eshop.Migrations
{
    /// <inheritdoc />
    public partial class ClientComplexTypeRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27a51c7b-afb6-44fb-936e-782a3c05802f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56a6762f-4bbd-47bb-94dc-617c24c10bc0");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Order",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "ClientPhone",
                table: "Order",
                newName: "client_phone");

            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Order",
                newName: "client_name");

            migrationBuilder.RenameColumn(
                name: "ClientEmail",
                table: "Order",
                newName: "client_email");

            migrationBuilder.RenameColumn(
                name: "DateOfCreation",
                table: "Order",
                newName: "created_at");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bdc9adda-cba4-43d1-b579-81cb927a1754", null, "Admin", "ADMIN" },
                    { "d39dbffe-ac05-4953-b049-b97f556e60fe", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Count", "Price" },
                values: new object[] { 89.5, 3243.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Count", "Price" },
                values: new object[] { 87.0, 1926.99 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Count", "Price" },
                values: new object[] { 76.5, 3581.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Count", "Price" },
                values: new object[] { 52.0, 1011.99 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Count", "Price" },
                values: new object[] { 31.5, 4243.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Count", "Price" },
                values: new object[] { 28.0, 4878.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Count", "Price" },
                values: new object[] { 102.5, 5297.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Count", "Price" },
                values: new object[] { 86.0, 7756.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Count", "Price" },
                values: new object[] { 47.5, 4310.9899999999998 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Count", "Price" },
                values: new object[] { 53.0, 533.99000000000001 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdc9adda-cba4-43d1-b579-81cb927a1754");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d39dbffe-ac05-4953-b049-b97f556e60fe");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Order",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "client_phone",
                table: "Order",
                newName: "ClientPhone");

            migrationBuilder.RenameColumn(
                name: "client_name",
                table: "Order",
                newName: "ClientName");

            migrationBuilder.RenameColumn(
                name: "client_email",
                table: "Order",
                newName: "ClientEmail");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Order",
                newName: "DateOfCreation");

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
    }
}
