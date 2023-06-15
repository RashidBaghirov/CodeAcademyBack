using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAcademy.Migrations
{
    public partial class ChangedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "EduModels");

            migrationBuilder.AddColumn<string>(
                name: "Name_left",
                table: "EduModels",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_right",
                table: "EduModels",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_left",
                table: "EduModels");

            migrationBuilder.DropColumn(
                name: "Name_right",
                table: "EduModels");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EduModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
