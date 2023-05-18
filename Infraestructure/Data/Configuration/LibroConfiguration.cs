using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libros");
            builder.Property(p => p.isbn)
                    .IsRequired();
            builder.Property(p => p.titulo)
                    .IsRequired()
                    .HasMaxLength(255);
            builder.Property(p => p.sinopsis)
                    .IsRequired()
                    .HasMaxLength(600);
            builder.Property(p => p.n_paginas)
                    .IsRequired()
                    .HasMaxLength(45);
            builder.HasOne(p => p.Editorial)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(p => p.EditorialId);

        }

    }
}
