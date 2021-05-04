using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectShopping.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainCategory",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    PID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    size = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => new { x.PID, x.color, x.size });
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "PID", "Description", "Gender", "MainCategory", "Name", "Price" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "aasdf as dfgaskjdf askdfh askjdfh lasdf", "Men", "Shirt", "abcd", 20 });

            migrationBuilder.InsertData(
                table: "AllTags",
                columns: new[] { "PID", "tag" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "cotton" });

            migrationBuilder.InsertData(
                table: "AllTags",
                columns: new[] { "PID", "tag" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Full-sleves" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DeleteData(
                table: "AllTags",
                keyColumns: new[] { "PID", "tag" },
                keyValues: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "cotton" });

            migrationBuilder.DeleteData(
                table: "AllTags",
                keyColumns: new[] { "PID", "tag" },
                keyValues: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Full-sleves" });

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "PID",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "products");

            migrationBuilder.DropColumn(
                name: "MainCategory",
                table: "products");
        }
    }
}
