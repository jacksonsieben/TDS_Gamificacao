﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoGerenciamentoRestaurante.RazorPages.Data;

#nullable disable

namespace ProjetoGerenciamentoRestaurante.RazorPages.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230412041348_addColunaDataAtendimento")]
    partial class addColunaDataAtendimento
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.AtendimentoModel", b =>
                {
                    b.Property<int>("AtendimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AtendimentoFechado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataSaida")
                        .HasColumnType("TEXT");

                    b.Property<int>("MesaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AtendimentoId");

                    b.HasIndex("MesaId");

                    b.ToTable("Atendimento", (string)null);
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.CategoriaModel", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.GarconModel", b =>
                {
                    b.Property<int>("GarconId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GarconId");

                    b.ToTable("Garcon", (string)null);
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.MesaModel", b =>
                {
                    b.Property<int>("MesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("HoraAbertura")
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("MesaId");

                    b.ToTable("Mesa", (string)null);
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.PedidoModel", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AtendimentoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GarconId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("HorarioPedido")
                        .HasColumnType("TEXT");

                    b.HasKey("PedidoId");

                    b.HasIndex("AtendimentoId");

                    b.HasIndex("GarconId");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.Pedido_ProdutoModel", b =>
                {
                    b.Property<int>("PedidoProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Quantidade")
                        .HasColumnType("REAL");

                    b.HasKey("PedidoProdutoId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Pedido_Produto", (string)null);
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.ProdutoModel", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Preco")
                        .HasColumnType("REAL");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.AtendimentoModel", b =>
                {
                    b.HasOne("ProjetoGerenciamentoRestaurante.RazorPages.Models.MesaModel", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.PedidoModel", b =>
                {
                    b.HasOne("ProjetoGerenciamentoRestaurante.RazorPages.Models.AtendimentoModel", "Atendimento")
                        .WithMany()
                        .HasForeignKey("AtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoGerenciamentoRestaurante.RazorPages.Models.GarconModel", "Garcon")
                        .WithMany()
                        .HasForeignKey("GarconId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atendimento");

                    b.Navigation("Garcon");
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.Pedido_ProdutoModel", b =>
                {
                    b.HasOne("ProjetoGerenciamentoRestaurante.RazorPages.Models.PedidoModel", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoGerenciamentoRestaurante.RazorPages.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.ProdutoModel", b =>
                {
                    b.HasOne("ProjetoGerenciamentoRestaurante.RazorPages.Models.CategoriaModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
