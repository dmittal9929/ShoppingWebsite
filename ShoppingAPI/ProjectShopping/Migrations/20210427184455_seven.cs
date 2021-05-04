using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectShopping.Migrations
{
    public partial class seven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orders_OID",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_users_UID",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_UserUID",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_products_ProductPID",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "IX_stocks_ProductPID",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "IX_orders_UserUID",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ProductPID",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "UserUID",
                table: "orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "UID",
                table: "carts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "OID",
                table: "carts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_orders_UID",
                table: "orders",
                column: "UID");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_orders_OID",
                table: "carts",
                column: "OID",
                principalTable: "orders",
                principalColumn: "OID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_UID",
                table: "carts",
                column: "UID",
                principalTable: "users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_UID",
                table: "orders",
                column: "UID",
                principalTable: "users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_products_PID",
                table: "stocks",
                column: "PID",
                principalTable: "products",
                principalColumn: "PID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orders_OID",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_users_UID",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_UID",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_products_PID",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "IX_orders_UID",
                table: "orders");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductPID",
                table: "stocks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserUID",
                table: "orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UID",
                table: "carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OID",
                table: "carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_stocks_ProductPID",
                table: "stocks",
                column: "ProductPID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserUID",
                table: "orders",
                column: "UserUID");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_orders_OID",
                table: "carts",
                column: "OID",
                principalTable: "orders",
                principalColumn: "OID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_UID",
                table: "carts",
                column: "UID",
                principalTable: "users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_UserUID",
                table: "orders",
                column: "UserUID",
                principalTable: "users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_products_ProductPID",
                table: "stocks",
                column: "ProductPID",
                principalTable: "products",
                principalColumn: "PID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
