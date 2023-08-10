using Microsoft.EntityFrameworkCore.Migrations;

namespace BANKA.Migrations
{
    public partial class bezKlijetID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KlijentiId",
                table: "Transakcije");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KlijentiId",
                table: "Transakcije",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
