using Microsoft.EntityFrameworkCore.Migrations;

namespace BANKA.Migrations
{
    public partial class addmigrationposlovnca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bankomatis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    novacUBankomatu = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankomatis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poslovnice",
                columns: table => new
                {
                    PoslovnicaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZaposlenikID = table.Column<int>(type: "int", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mjesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kontakt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poslovnice", x => x.PoslovnicaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bankomatis");

            migrationBuilder.DropTable(
                name: "Poslovnice");
        }
    }
}
