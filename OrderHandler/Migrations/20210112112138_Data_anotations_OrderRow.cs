using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderHandler.Data.Migrations
{
    public partial class Data_anotations_OrderRow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderRows",
                table: "OrderRows");

            migrationBuilder.DropIndex(
                name: "IX_OrderRows_OrderRows",
                table: "OrderRows");

            migrationBuilder.DropColumn(
                name: "OrderRows",
                table: "OrderRows");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderRows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderRows_OrderId",
                table: "OrderRows",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows");

            migrationBuilder.DropIndex(
                name: "IX_OrderRows_OrderId",
                table: "OrderRows");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderRows");

            migrationBuilder.AddColumn<int>(
                name: "OrderRows",
                table: "OrderRows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderRows_OrderRows",
                table: "OrderRows",
                column: "OrderRows");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderRows",
                table: "OrderRows",
                column: "OrderRows",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
