using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAcademy.Migrations
{
    public partial class Addcolumnss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Graduants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Graduants");
        }
    }
}
