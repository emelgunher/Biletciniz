using Microsoft.EntityFrameworkCore.Migrations;

namespace Biletciniz.Data.Migrations
{
    public partial class MüşteriUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MusteriID",
                table: "Bilet",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_MusteriID",
                table: "Bilet",
                column: "MusteriID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bilet_AspNetUsers_MusteriID",
                table: "Bilet",
                column: "MusteriID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bilet_AspNetUsers_MusteriID",
                table: "Bilet");

            migrationBuilder.DropIndex(
                name: "IX_Bilet_MusteriID",
                table: "Bilet");

            migrationBuilder.DropColumn(
                name: "MusteriID",
                table: "Bilet");
        }
    }
}
