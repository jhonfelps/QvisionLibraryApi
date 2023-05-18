using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Models;

namespace Infraestructure.Data.Configuration
{
    public class EditorialConfiguration : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.ToTable("Editoriales");
            builder.Property(p => p.id)
                    .IsRequired();
            builder.Property(p => p.nombre)
                    .IsRequired()
                    .HasMaxLength(45);
            builder.Property(p => p.sede)
                    .IsRequired()
                    .HasMaxLength(45);
        }

    }
}
