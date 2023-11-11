using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class TipoAsignaturaConfiguration : IEntityTypeConfiguration<TipoAsignatura>
{
    public void Configure(EntityTypeBuilder<TipoAsignatura> builder)
    {
        builder.ToTable("tipoAsignatura");

        builder.Property(x => x.Descripcion)
        .HasMaxLength(50)
        .IsRequired();

        builder.HasData(
            new TipoAsignatura { Id = 1, Descripcion = "Basica"},
            new TipoAsignatura { Id = 2, Descripcion = "Obligatoria"},
            new TipoAsignatura { Id = 3, Descripcion = "Optativa"}
        );
    }
}