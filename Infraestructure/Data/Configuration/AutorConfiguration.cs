using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");
            builder.Property(p => p.id)
                    .IsRequired();
            builder.Property(p => p.nombre)
                    .IsRequired()
                    .HasMaxLength(200);
            builder.Property(p => p.apellidos)
                    .IsRequired()
                    .HasMaxLength(200);
        }
    }
}
