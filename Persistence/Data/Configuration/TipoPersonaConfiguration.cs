using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
{
    public void Configure(EntityTypeBuilder<TipoPersona> builder)
    {
        builder.ToTable("tipoPersona");

        builder.Property(x => x.Descripcion)
        .HasMaxLength(50)
        .IsRequired();

        builder.HasData(
            new TipoPersona { Id = 1, Descripcion = "Alumno"},
            new TipoPersona { Id = 2, Descripcion = "Profesor"}
        );
    }
}