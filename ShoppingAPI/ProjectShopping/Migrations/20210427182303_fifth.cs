using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectShopping.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orders_orderOID",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_products_prductPID",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_users_userUID",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_orderOID",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_prductPID",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_userUID",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "orderOID",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "prductPID",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "userUID",
                table: "carts");

            migrationBuilder.CreateIndex(
                name: "IX_carts_OID",
                table: "carts",
                column: "OID");

            migrationBuilder.CreateIndex(
                name: "IX_carts_PID",
                table: "carts",
                column: "PID");

            migrationBuilder.CreateIndex(
                name: "IX_carts_UID",
                table: "carts",
                column: "UID");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_orders_OID",
                table: "carts",
                column: "OID",
                principalTable: "orders",
                principalColumn: "OID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_products_PID",
                table: "carts",
                column: "PID",
                principalTable: "products",
                principalColumn: "PID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_UID",
                table: "carts",
                column: "UID",
                principalTable: "users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orders_OID",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_products_PID",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_users_UID",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_OID",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_PID",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_UID",
                table: "carts");

            migrationBuilder.AddColumn<Guid>(
                name: "orderOID",
                table: "carts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "prductPID",
                table: "carts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "userUID",
                table: "carts",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "FK_carts_orders_orderOID",
                table: "carts",
                column: "orderOID",
                principalTable: "orders",
                principalColumn: "OID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_products_prductPID",
                table: "carts",
                column: "prductPID",
                principalTable: "products",
                principalColumn: "PID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_userUID",
                table: "carts",
                column: "userUID",
                principalTable: "users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
