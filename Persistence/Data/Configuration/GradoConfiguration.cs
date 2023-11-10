using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class GradoConfiguration : IEntityTypeConfiguration<Grado>
{
    public void Configure(EntityTypeBuilder<Grado> builder)
    {
        builder.ToTable("grado");

        builder.Property(x => x.Nombre)
        .HasMaxLength(50)
        .IsRequired();
    }
}