using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.Property(x => x.Nif)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.PrimerApellido)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.SegundoApellido)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Ciudad)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Direccion)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Telefono)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.FechaNacimiento)
        .HasColumnType("date")
        .IsRequired();
    }
}