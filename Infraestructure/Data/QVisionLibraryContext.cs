using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infraestructure.Data
{
    public class QVisionLibraryContext : DbContext
    {
        public QVisionLibraryContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
            .HasMany(e => e.Autores)
            .WithMany(e => e.Libros)
            .UsingEntity<AutoresLibros>(
                l => l.HasOne<Autor>().WithMany().HasForeignKey(e => e.AutorId),
                r => r.HasOne<Libro>().WithMany().HasForeignKey(e => e.LibroIsbn));

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
