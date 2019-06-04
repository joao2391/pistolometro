using Microsoft.EntityFrameworkCore.Migrations;

namespace Pistolometro.Migrations
{
    public partial class ChangeTypeIdUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "Votacao",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "Votacao",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
