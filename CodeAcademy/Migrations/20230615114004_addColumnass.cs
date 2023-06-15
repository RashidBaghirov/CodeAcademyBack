using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAcademy.Migrations
{
    public partial class addColumnass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Professions");

            migrationBuilder.AddColumn<string>(
                name: "Detail_Answer",
                table: "EducationModes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Detail_Desc",
                table: "EducationModes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Detail_Questions",
                table: "EducationModes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Others",
                table: "EducationModes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "EducationModes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ModePhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationModeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModePhotos_EducationModes_EducationModeId",
                        column: x => x.EducationModeId,
                        principalTable: "EducationModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModePhotos_EducationModeId",
                table: "ModePhotos",
                column: "EducationModeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModePhotos");

            migrationBuilder.DropColumn(
                name: "Detail_Answer",
                table: "EducationModes");

            migrationBuilder.DropColumn(
                name: "Detail_Desc",
                table: "EducationModes");

            migrationBuilder.DropColumn(
                name: "Detail_Questions",
                table: "EducationModes");

            migrationBuilder.DropColumn(
                name: "Others",
                table: "EducationModes");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "EducationModes");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Professions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
