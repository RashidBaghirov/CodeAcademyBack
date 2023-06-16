using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAcademy.Migrations
{
    public partial class Addcolumnsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Graduants",
                newName: "SurName");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Graduants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Graduants");

            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Graduants",
                newName: "Fullname");
        }
    }
}
