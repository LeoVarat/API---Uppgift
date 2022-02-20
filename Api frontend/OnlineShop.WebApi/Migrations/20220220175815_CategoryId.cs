using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.WebApi.Migrations
{
    public partial class CategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryIdId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryIdId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryIdId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CatId",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "CatId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryIdId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryIdId",
                table: "Product",
                column: "CategoryIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryIdId",
                table: "Product",
                column: "CategoryIdId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
