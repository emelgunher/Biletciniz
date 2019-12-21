using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biletciniz.Data.Migrations
{
    public partial class SatistaYakinda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BaslangicTarihi",
                table: "Etkinlik",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BitisTarihi",
                table: "Etkinlik",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaslangicTarihi",
                table: "Etkinlik");

            migrationBuilder.DropColumn(
                name: "BitisTarihi",
                table: "Etkinlik");
        }
    }
}
