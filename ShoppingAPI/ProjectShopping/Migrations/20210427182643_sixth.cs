using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectShopping.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_products_ProductPID",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ProductPID",
                table: "orders",
                newName: "UserUID");

            migrationBuilder.RenameIndex(
                name: "IX_orders_ProductPID",
                table: "orders",
                newName: "IX_orders_UserUID");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_UserUID",
                table: "orders",
                column: "UserUID",
                principalTable: "users",
                principalColumn: "UID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_UserUID",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "UserUID",
                table: "orders",
                newName: "ProductPID");

            migrationBuilder.RenameIndex(
                name: "IX_orders_UserUID",
                table: "orders",
                newName: "IX_orders_ProductPID");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_products_ProductPID",
                table: "orders",
                column: "ProductPID",
                principalTable: "products",
                principalColumn: "PID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
