using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebKuaforProje.Migrations
{
    /// <inheritdoc />
    public partial class Sube : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subeler",
                columns: table => new
                {
                    Sehir = table.Column<string>(type: "text", nullable: false),
                    Isim = table.Column<string>(type: "text", nullable: false),
                    TamAdres = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subeler", x => x.Sehir);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subeler");
        }
    }
}
