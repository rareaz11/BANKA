using Microsoft.EntityFrameworkCore.Migrations;

namespace BANKA.Migrations
{
    public partial class bezOsobno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transakcije_Klijenti_KlijentiId",
                table: "Transakcije");

            migrationBuilder.DropIndex(
                name: "IX_Transakcije_KlijentiId",
                table: "Transakcije");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transakcije_KlijentiId",
                table: "Transakcije",
                column: "KlijentiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transakcije_Klijenti_KlijentiId",
                table: "Transakcije",
                column: "KlijentiId",
                principalTable: "Klijenti",
                principalColumn: "KlijentiId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
