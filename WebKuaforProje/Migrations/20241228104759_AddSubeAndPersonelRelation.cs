using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebKuaforProje.Migrations
{
    /// <inheritdoc />
    public partial class AddSubeAndPersonelRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Personeller_Subesi",
                table: "Personeller",
                column: "Subesi");

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Subeler_Subesi",
                table: "Personeller",
                column: "Subesi",
                principalTable: "Subeler",
                principalColumn: "Sehir",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Subeler_Subesi",
                table: "Personeller");

            migrationBuilder.DropIndex(
                name: "IX_Personeller_Subesi",
                table: "Personeller");
        }
    }
}
