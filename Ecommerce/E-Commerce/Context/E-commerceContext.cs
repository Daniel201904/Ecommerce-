using Base_de_datos;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_Commerce.Context
{
    public class E_commerceContext : DbContext
    {
        public E_commerceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Auditorias> Auditorias { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfuguration(modelBuilder);
        }

        private void EntityConfuguration(ModelBuilder modelBuilder)
        {
            //tabla auditorias
            modelBuilder.Entity<Auditorias>().ToTable("Auditorias");
            modelBuilder.Entity<Auditorias> ().HasKey(u => u.Id);
            modelBuilder.Entity<Auditorias> ().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Auditorias> ().Property(u => u.UsuarioId).HasColumnName("UsuarioId");
            modelBuilder.Entity<Auditorias> ().Property(u => u.Usuario).HasColumnName("Usuario");
            modelBuilder.Entity<Auditorias>().Property(u => u.Accion).HasColumnName("Accion");
            modelBuilder.Entity<Auditorias>().Property(u => u.FechaAccion).HasColumnName("FechaAccion");

            //tabla categoria
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Categoria>().HasKey(u => u.Id);
            modelBuilder.Entity<Categoria>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Categoria>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<Categoria>().Property(u => u.Productos).HasColumnName("Productos");
        }
        a
       
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
