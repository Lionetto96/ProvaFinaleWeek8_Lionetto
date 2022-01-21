using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rubrica_RepositoryEF.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indirizzo",
                columns: table => new
                {
                    IndirizzoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipologia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Via = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Città = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cap = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nazione = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ContattoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indirizzo", x => x.IndirizzoId);
                    table.ForeignKey(
                        name: "FKContatto",
                        column: x => x.ContattoId,
                        principalTable: "Contatto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Indirizzo_ContattoId",
                table: "Indirizzo",
                column: "ContattoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indirizzo");

            migrationBuilder.DropTable(
                name: "Contatto");
        }
    }
}
