using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectShopping.Migrations
{
    public partial class cartupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orders_OID",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_users_UID",
                table: "carts");

            migrationBuilder.RenameColumn(
                name: "UID",
                table: "carts",
                newName: "UserUID");

            migrationBuilder.RenameIndex(
                name: "IX_carts_UID",
                table: "carts",
                newName: "IX_carts_UserUID");

            migrationBuilder.AlterColumn<Guid>(
                name: "OID",
                table: "carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_orders_OID",
                table: "carts",
                column: "OID",
                principalTable: "orders",
                principalColumn: "OID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_UserUID",
                table: "carts",
                column: "UserUID",
                principalTable: "users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_orders_OID",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_users_UserUID",
                table: "carts");

            migrationBuilder.RenameColumn(
                name: "UserUID",
                table: "carts",
                newName: "UID");

            migrationBuilder.RenameIndex(
                name: "IX_carts_UserUID",
                table: "carts",
                newName: "IX_carts_UID");

            migrationBuilder.AlterColumn<Guid>(
                name: "OID",
                table: "carts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
        }
    }
}
