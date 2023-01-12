using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectMedii.Migrations
{
    public partial class BookCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(maxLength: 70, nullable: false),
                    Profesor_Titular = table.Column<string>(maxLength: 50, nullable: false),
                    Nr_credite = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Inrolare",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false),
                    Nota = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inrolare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inrolare_Curs_CursID",
                        column: x => x.CursID,
                        principalTable: "Curs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inrolare_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inrolare_CursID",
                table: "Inrolare",
                column: "CursID");

            migrationBuilder.CreateIndex(
                name: "IX_Inrolare_StudentID",
                table: "Inrolare",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inrolare");

            migrationBuilder.DropTable(
                name: "Curs");
        }
    }
}
