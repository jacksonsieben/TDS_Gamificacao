using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoGerenciamentoRestaurante.RazorPages.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    MesaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    HoraAbertura = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.MesaId);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    AtendimentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MesaId = table.Column<int>(type: "INTEGER", nullable: false),
                    HorarioPedido = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.AtendimentoId);
                    table.ForeignKey(
                        name: "FK_Atendimento_Mesa_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesa",
                        principalColumn: "MesaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garcon",
                columns: table => new
                {
                    GarconId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    AtendimentoModelAtendimentoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garcon", x => x.GarconId);
                    table.ForeignKey(
                        name: "FK_Garcon_Atendimento_AtendimentoModelAtendimentoId",
                        column: x => x.AtendimentoModelAtendimentoId,
                        principalTable: "Atendimento",
                        principalColumn: "AtendimentoId");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false),
                    Id_Categoria = table.Column<int>(type: "INTEGER", nullable: false),
                    AtendimentoModelAtendimentoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produto_Atendimento_AtendimentoModelAtendimentoId",
                        column: x => x.AtendimentoModelAtendimentoId,
                        principalTable: "Atendimento",
                        principalColumn: "AtendimentoId");
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_Id_Categoria",
                        column: x => x.Id_Categoria,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_MesaId",
                table: "Atendimento",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Garcon_AtendimentoModelAtendimentoId",
                table: "Garcon",
                column: "AtendimentoModelAtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_AtendimentoModelAtendimentoId",
                table: "Produto",
                column: "AtendimentoModelAtendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Id_Categoria",
                table: "Produto",
                column: "Id_Categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garcon");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Mesa");
        }
    }
}
