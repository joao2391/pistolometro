using Microsoft.EntityFrameworkCore.Migrations;

namespace Pistolometro.Data.Migrations
{
    public partial class FixedVotacaoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeVencedor",
                table: "Votacao",
                newName: "NomeVencedorId");

            migrationBuilder.AlterColumn<string>(
                name: "NomeVencedorId",
                table: "Votacao",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votacao_NomeVencedorId",
                table: "Votacao",
                column: "NomeVencedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votacao_AspNetUsers_NomeVencedorId",
                table: "Votacao",
                column: "NomeVencedorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votacao_AspNetUsers_NomeVencedorId",
                table: "Votacao");

            migrationBuilder.DropIndex(
                name: "IX_Votacao_NomeVencedorId",
                table: "Votacao");

            migrationBuilder.RenameColumn(
                name: "NomeVencedorId",
                table: "Votacao",
                newName: "NomeVencedor");

            migrationBuilder.AlterColumn<string>(
                name: "NomeVencedor",
                table: "Votacao",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
