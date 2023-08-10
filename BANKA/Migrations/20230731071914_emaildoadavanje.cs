using Microsoft.EntityFrameworkCore.Migrations;

namespace BANKA.Migrations
{
    public partial class emaildoadavanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "emailKorisnik",
                table: "Klijenti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "mobitel",
                table: "Klijenti",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emailKorisnik",
                table: "Klijenti");

            migrationBuilder.DropColumn(
                name: "mobitel",
                table: "Klijenti");
        }
    }
}
