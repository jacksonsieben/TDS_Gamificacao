using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoGerenciamentoRestaurante.RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class addColunaStatusAtendimentoCorrige : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AtedimentoFechado",
                table: "Atendimento",
                newName: "AtendimentoFechado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AtendimentoFechado",
                table: "Atendimento",
                newName: "AtedimentoFechado");
        }
    }
}
