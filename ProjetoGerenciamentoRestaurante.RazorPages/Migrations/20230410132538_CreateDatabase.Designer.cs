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
    [Migration("20230410132538_CreateDatabase")]
    partial class CreateDatabase
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

                    b.Property<DateTime>("HorarioPedido")
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

                    b.Property<int?>("AtendimentoModelAtendimentoId")
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

                    b.HasIndex("AtendimentoModelAtendimentoId");

                    b.ToTable("Garcon", (string)null);
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.MesaModel", b =>
                {
                    b.Property<int>("MesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("HoraAbertura")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("MesaId");

                    b.ToTable("Mesa", (string)null);
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.ProdutoModel", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AtendimentoModelAtendimentoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Id_Categoria")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preco")
                        .HasColumnType("TEXT");

                    b.HasKey("ProdutoId");

                    b.HasIndex("AtendimentoModelAtendimentoId");

                    b.HasIndex("Id_Categoria");

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

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.GarconModel", b =>
                {
                    b.HasOne("ProjetoGerenciamentoRestaurante.RazorPages.Models.AtendimentoModel", null)
                        .WithMany("Garcons")
                        .HasForeignKey("AtendimentoModelAtendimentoId");
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.ProdutoModel", b =>
                {
                    b.HasOne("ProjetoGerenciamentoRestaurante.RazorPages.Models.AtendimentoModel", null)
                        .WithMany("Produtos")
                        .HasForeignKey("AtendimentoModelAtendimentoId");

                    b.HasOne("ProjetoGerenciamentoRestaurante.RazorPages.Models.CategoriaModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("Id_Categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("ProjetoGerenciamentoRestaurante.RazorPages.Models.AtendimentoModel", b =>
                {
                    b.Navigation("Garcons");

                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}