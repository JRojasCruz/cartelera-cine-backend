using CineCartelera.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CineCartelera.API.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Funcion>()
                .HasOne(f => f.Pelicula)
                .WithMany(p => p.Funciones)
                .HasForeignKey(f => f.PeliculaId);

            modelBuilder.Entity<Funcion>()
                .HasOne(f => f.Sala)
                .WithMany(s => s.Funciones)
                .HasForeignKey(f => f.SalaId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Funcion)
                .WithMany(f => f.Reservas)
                .HasForeignKey(r => r.FuncionId);
        }
    }
}
