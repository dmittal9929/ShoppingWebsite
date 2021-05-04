using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectShopping.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_UID",
                table: "carts",
                column: "UID",
                principalTable: "users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_UserUID",
                table: "carts",
                column: "UserUID",
                principalTable: "users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
