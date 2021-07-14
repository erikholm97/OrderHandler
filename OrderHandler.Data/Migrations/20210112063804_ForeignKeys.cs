using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderHandler.Data.Migrations
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Articles_ArticleId",
                table: "OrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderRows",
                newName: "OrderRows");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_OrderId",
                table: "OrderRows",
                newName: "IX_OrderRows_OrderRows");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "OrderRows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleNumber",
                table: "Articles",
                column: "ArticleNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Articles_ArticleId",
                table: "OrderRows",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderRows",
                table: "OrderRows",
                column: "OrderRows",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Articles_ArticleId",
                table: "OrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderRows",
                table: "OrderRows");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleNumber",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "OrderRows",
                table: "OrderRows",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_OrderRows",
                table: "OrderRows",
                newName: "IX_OrderRows_OrderId");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "OrderRows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Articles_ArticleId",
                table: "OrderRows",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
