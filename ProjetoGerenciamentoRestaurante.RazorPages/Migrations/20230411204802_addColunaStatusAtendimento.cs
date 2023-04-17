using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoGerenciamentoRestaurante.RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class addColunaStatusAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AtedimentoFechado",
                table: "Atendimento",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtedimentoFechado",
                table: "Atendimento");
        }
    }
}
