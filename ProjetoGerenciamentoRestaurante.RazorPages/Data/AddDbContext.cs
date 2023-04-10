using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Data{
    public class AddDbContext : DbContext
    {
        public DbSet<GarconModel>? Garcon {get; set;}
        public DbSet<MesaModel>? Mesa {get; set;}
        public DbSet<ProdutoModel>? Produto {get; set;}
        public DbSet<CategoriaModel>? Categoria {get; set;}
        public DbSet<AtendimentoModel>? Atendimento {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=restaurante_db.db;Cache=Shared");
            
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<GarconModel>().ToTable("Garcon");
            modelBuilder.Entity<MesaModel>().ToTable("Mesa");
            modelBuilder.Entity<AtendimentoModel>().ToTable("Atendimento");
            modelBuilder.Entity<CategoriaModel>().ToTable("Categoria");
            modelBuilder.Entity<ProdutoModel>().ToTable("Produto");
        }
    }
}