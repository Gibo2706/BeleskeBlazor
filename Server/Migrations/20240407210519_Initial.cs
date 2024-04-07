using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeleskeBlazor.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beleska",
                columns: table => new
                {
                    IdBeleska = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    redniBroj = table.Column<int>(type: "int", nullable: false),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dokument = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    idStudent = table.Column<int>(type: "int", nullable: false),
                    idCas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beleska", x => x.IdBeleska);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beleska");
        }
    }
}
