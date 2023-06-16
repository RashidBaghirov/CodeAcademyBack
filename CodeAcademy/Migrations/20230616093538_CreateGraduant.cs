using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAcademy.Migrations
{
    public partial class CreateGraduant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Graduants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sentence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationModeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graduants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Graduants_EducationModes_EducationModeId",
                        column: x => x.EducationModeId,
                        principalTable: "EducationModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Graduants_EducationModeId",
                table: "Graduants",
                column: "EducationModeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Graduants");
        }
    }
}
