using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAcademy.Migrations
{
    public partial class addColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationModeId",
                table: "Professions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Professions_EducationModeId",
                table: "Professions",
                column: "EducationModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_EducationModes_EducationModeId",
                table: "Professions",
                column: "EducationModeId",
                principalTable: "EducationModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professions_EducationModes_EducationModeId",
                table: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_Professions_EducationModeId",
                table: "Professions");

            migrationBuilder.DropColumn(
                name: "EducationModeId",
                table: "Professions");
        }
    }
}
