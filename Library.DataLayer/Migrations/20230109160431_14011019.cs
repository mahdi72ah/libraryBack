using Microsoft.EntityFrameworkCore.Migrations;

namespace library.DataLayer.Migrations
{
    public partial class _14011019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "icon",
                table: "menu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link",
                table: "menu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icon",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "link",
                table: "menu");
        }
    }
}
