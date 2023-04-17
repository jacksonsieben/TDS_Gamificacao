using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoGerenciamentoRestaurante.RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class addColunaDataAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Atendimento",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSaida",
                table: "Atendimento",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "DataSaida",
                table: "Atendimento");
        }
    }
}
