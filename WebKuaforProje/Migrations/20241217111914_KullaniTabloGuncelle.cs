using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebKuaforProje.Migrations
{
    /// <inheritdoc />
    public partial class KullaniTabloGuncelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Kullanici",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Soyad",
                table: "Kullanici",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelefonNo",
                table: "Kullanici",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Kullanici");

            migrationBuilder.DropColumn(
                name: "Soyad",
                table: "Kullanici");

            migrationBuilder.DropColumn(
                name: "TelefonNo",
                table: "Kullanici");
        }
    }
}
