using Microsoft.EntityFrameworkCore.Migrations;

namespace WebKuaforProje.Migrations
{
    public partial class VeriTabaniKontrol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Kullanıcı tablosu siliniyor
            migrationBuilder.DropTable(
                name: "Kullanici");
        }
    }
}
