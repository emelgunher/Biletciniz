using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biletciniz.Data.Migrations
{
    public partial class EkleTablolar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sehir",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehir", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tur",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(nullable: true),
                    KategoriID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tur", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tur_Kategori_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategori",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ilce",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlceAdi = table.Column<string>(nullable: true),
                    SehirID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ilce_Sehir_SehirID",
                        column: x => x.SehirID,
                        principalTable: "Sehir",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sanatci",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(nullable: true),
                    Soyadi = table.Column<string>(nullable: true),
                    DogumTarihi = table.Column<DateTime>(nullable: false),
                    SehirID = table.Column<int>(nullable: false),
                    Cinsiyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanatci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sanatci_Sehir_SehirID",
                        column: x => x.SehirID,
                        principalTable: "Sehir",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mekan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MekanAdi = table.Column<string>(nullable: true),
                    Kapasite = table.Column<int>(nullable: false),
                    SehirID = table.Column<int>(nullable: false),
                    IlceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mekan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mekan_Ilce_IlceID",
                        column: x => x.IlceID,
                        principalTable: "Ilce",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mekan_Sehir_SehirID",
                        column: x => x.SehirID,
                        principalTable: "Sehir",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Etkinlik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtkinlikAdi = table.Column<string>(nullable: true),
                    Tarih = table.Column<DateTime>(nullable: false),
                    Afis = table.Column<string>(nullable: true),
                    Süre = table.Column<int>(nullable: false),
                    KategoriID = table.Column<int>(nullable: false),
                    TurID = table.Column<int>(nullable: false),
                    MekanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Etkinlik_Kategori_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategori",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Etkinlik_Mekan_MekanID",
                        column: x => x.MekanID,
                        principalTable: "Mekan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Etkinlik_Tur_TurID",
                        column: x => x.TurID,
                        principalTable: "Tur",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bilet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtkinlikID = table.Column<int>(nullable: false),
                    KoltukNo = table.Column<int>(nullable: false),
                    SatisTarihi = table.Column<DateTime>(nullable: false),
                    Fiyat = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bilet_Etkinlik_EtkinlikID",
                        column: x => x.EtkinlikID,
                        principalTable: "Etkinlik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtkinlikSanatci",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanatciID = table.Column<int>(nullable: false),
                    EtkinlikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtkinlikSanatci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EtkinlikSanatci_Etkinlik_EtkinlikID",
                        column: x => x.EtkinlikID,
                        principalTable: "Etkinlik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtkinlikSanatci_Sanatci_SanatciID",
                        column: x => x.SanatciID,
                        principalTable: "Sanatci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_EtkinlikID",
                table: "Bilet",
                column: "EtkinlikID");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlik_KategoriID",
                table: "Etkinlik",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlik_MekanID",
                table: "Etkinlik",
                column: "MekanID");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinlik_TurID",
                table: "Etkinlik",
                column: "TurID");

            migrationBuilder.CreateIndex(
                name: "IX_EtkinlikSanatci_EtkinlikID",
                table: "EtkinlikSanatci",
                column: "EtkinlikID");

            migrationBuilder.CreateIndex(
                name: "IX_EtkinlikSanatci_SanatciID",
                table: "EtkinlikSanatci",
                column: "SanatciID");

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_SehirID",
                table: "Ilce",
                column: "SehirID");

            migrationBuilder.CreateIndex(
                name: "IX_Mekan_IlceID",
                table: "Mekan",
                column: "IlceID");

            migrationBuilder.CreateIndex(
                name: "IX_Mekan_SehirID",
                table: "Mekan",
                column: "SehirID");

            migrationBuilder.CreateIndex(
                name: "IX_Sanatci_SehirID",
                table: "Sanatci",
                column: "SehirID");

            migrationBuilder.CreateIndex(
                name: "IX_Tur_KategoriID",
                table: "Tur",
                column: "KategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilet");

            migrationBuilder.DropTable(
                name: "EtkinlikSanatci");

            migrationBuilder.DropTable(
                name: "Etkinlik");

            migrationBuilder.DropTable(
                name: "Sanatci");

            migrationBuilder.DropTable(
                name: "Mekan");

            migrationBuilder.DropTable(
                name: "Tur");

            migrationBuilder.DropTable(
                name: "Ilce");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Sehir");
        }
    }
}
