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
        .HasMaxLength(100)
        .IsRequired();

        builder.HasData(
            new Grado { Id = 1, Nombre = "Grado en Ingeniería Agrícola (Plan 2015)"},
            new Grado { Id = 2, Nombre = "Grado en Ingeniería Eléctrica (Plan 2014)"},
            new Grado { Id = 3, Nombre = "Grado en Ingeniería Electrónica Industrial (Plan 2010)"},
            new Grado { Id = 4, Nombre = "Grado en Ingeniería Informática (Plan 2015)"},
            new Grado { Id = 5, Nombre = "Grado en Ingeniería Mecánica (Plan 2010)"},
            new Grado { Id = 6, Nombre = "Grado en Ingeniería Química Industrial (Plan 2010)"},
            new Grado { Id = 7, Nombre = "Grado en Biotecnología (Plan 2015)"},
            new Grado { Id = 8, Nombre = "Grado en Ciencias Ambientales (Plan 2009)"},
            new Grado { Id = 9, Nombre = "Grado en Matemáticas (Plan 2010)"},
            new Grado { Id = 10, Nombre = "Grado en Química (Plan 2009)"}
        );
    }
}