using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BANKA.Migrations
{
    public partial class @for : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klijenti",
                columns: table => new
                {
                    KlijentiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OIB = table.Column<float>(type: "real", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    korisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojRacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stanjeRacuna = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.KlijentiId);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenici",
                columns: table => new
                {
                    ZaposleniciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OIB = table.Column<float>(type: "real", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenici", x => x.ZaposleniciId);
                });

            migrationBuilder.CreateTable(
                name: "Transakcije",
                columns: table => new
                {
                    TransId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlijentiId = table.Column<int>(type: "int", nullable: false),
                    OIB = table.Column<float>(type: "real", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imeUplatitelja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vrijemeUplate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    imeBanke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iznos = table.Column<double>(type: "float", nullable: false),
                    brZiroRacu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transakcije", x => x.TransId);
                    table.ForeignKey(
                        name: "FK_Transakcije_Klijenti_KlijentiId",
                        column: x => x.KlijentiId,
                        principalTable: "Klijenti",
                        principalColumn: "KlijentiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OsobniPodatci",
                columns: table => new
                {
                    OsobniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZaposleniciId = table.Column<int>(type: "int", nullable: false),
                    OIB = table.Column<float>(type: "real", nullable: false),
                    IsDirektor = table.Column<bool>(type: "bit", nullable: false),
                    IsBankar = table.Column<bool>(type: "bit", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobitel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodeanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalonst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dob = table.Column<int>(type: "int", nullable: false),
                    datumZaposljenja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsobniPodatci", x => x.OsobniId);
                    table.ForeignKey(
                        name: "FK_OsobniPodatci_Zaposlenici_ZaposleniciId",
                        column: x => x.ZaposleniciId,
                        principalTable: "Zaposlenici",
                        principalColumn: "ZaposleniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OsobniPodatci_ZaposleniciId",
                table: "OsobniPodatci",
                column: "ZaposleniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcije_KlijentiId",
                table: "Transakcije",
                column: "KlijentiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OsobniPodatci");

            migrationBuilder.DropTable(
                name: "Transakcije");

            migrationBuilder.DropTable(
                name: "Zaposlenici");

            migrationBuilder.DropTable(
                name: "Klijenti");
        }
    }
}
