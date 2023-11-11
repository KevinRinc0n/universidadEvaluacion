using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class SexoConfiguration : IEntityTypeConfiguration<Sexo>
{
    public void Configure(EntityTypeBuilder<Sexo> builder)
    {
        builder.ToTable("sexo");

        builder.Property(x => x.Descripcion)
        .HasMaxLength(50)
        .IsRequired();

        builder.HasData(
            new Sexo { Id = 1, Descripcion = "H"},
            new Sexo { Id = 2, Descripcion = "M"}
        );
    }
}