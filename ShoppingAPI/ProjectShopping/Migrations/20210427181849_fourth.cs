using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectShopping.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductPID",
                table: "stocks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductPID",
                table: "orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    CID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    prductPID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderOID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    qunatity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.CID);
                    table.ForeignKey(
                        name: "FK_carts_orders_orderOID",
                        column: x => x.orderOID,
                        principalTable: "orders",
                        principalColumn: "OID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_carts_products_prductPID",
                        column: x => x.prductPID,
                        principalTable: "products",
                        principalColumn: "PID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_carts_users_userUID",
                        column: x => x.userUID,
                        principalTable: "users",
                        principalColumn: "UID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stocks_ProductPID",
                table: "stocks",
                column: "ProductPID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ProductPID",
                table: "orders",
                column: "ProductPID");

            migrationBuilder.CreateIndex(
                name: "IX_carts_orderOID",
                table: "carts",
                column: "orderOID");

            migrationBuilder.CreateIndex(
                name: "IX_carts_prductPID",
                table: "carts",
                column: "prductPID");

            migrationBuilder.CreateIndex(
                name: "IX_carts_userUID",
                table: "carts",
                column: "userUID");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_ProductPID",
                table: "orders",
                column: "ProductPID",
                principalTable: "products",
                principalColumn: "PID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_products_ProductPID",
                table: "stocks",
                column: "ProductPID",
                principalTable: "products",
                principalColumn: "PID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_ProductPID",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_products_ProductPID",
                table: "stocks");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropIndex(
                name: "IX_stocks_ProductPID",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "IX_orders_ProductPID",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ProductPID",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "ProductPID",
                table: "orders");
        }
    }
}
