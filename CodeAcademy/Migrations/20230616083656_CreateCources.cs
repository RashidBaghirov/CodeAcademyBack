using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAcademy.Migrations
{
    public partial class CreateCources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationModeId",
                table: "Cources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cources_EducationModeId",
                table: "Cources",
                column: "EducationModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cources_EducationModes_EducationModeId",
                table: "Cources",
                column: "EducationModeId",
                principalTable: "EducationModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cources_EducationModes_EducationModeId",
                table: "Cources");

            migrationBuilder.DropIndex(
                name: "IX_Cources_EducationModeId",
                table: "Cources");

            migrationBuilder.DropColumn(
                name: "EducationModeId",
                table: "Cources");
        }
    }
}
