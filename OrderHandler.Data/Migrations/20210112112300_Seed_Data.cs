using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderHandler.Data.Migrations
{
    public partial class Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleName", "ArticleNumber", "Price" },
                values: new object[] { 1, "Träpall", 55555, 50 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerName" },
                values: new object[] { 1, "CGI" });

            migrationBuilder.InsertData(
                table: "OrderRows",
                columns: new[] { "Id", "ArticleAmount", "ArticleId", "OrderId", "RowNumber" },
                values: new object[] { 1, 13, 1, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
