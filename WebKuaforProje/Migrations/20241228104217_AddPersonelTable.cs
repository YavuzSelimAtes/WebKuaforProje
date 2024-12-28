using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebKuaforProje.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Subesi = table.Column<string>(type: "text", nullable: false),
                    UzmanlikAlani = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personeller_Kullanici_Id",
                        column: x => x.Id,
                        principalTable: "Kullanici",
                        principalColumn: "Kullanici_ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personeller");
        }
    }
}
