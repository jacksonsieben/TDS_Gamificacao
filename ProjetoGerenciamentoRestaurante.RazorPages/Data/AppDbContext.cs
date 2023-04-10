using ProjetoGerenciamentoRestaurante.RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Data{
    public class AppDbContext : DbContext
    {
        public DbSet<GarconModel>? Events {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=restaurante_db.db;Cache=Shared");
            
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<GarconModel>().ToTable("Garcon");
        }
    }
}