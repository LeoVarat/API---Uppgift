using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.WebApi.Migrations
{
    public partial class CatId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatId",
                table: "Product");
        }
    }
}
