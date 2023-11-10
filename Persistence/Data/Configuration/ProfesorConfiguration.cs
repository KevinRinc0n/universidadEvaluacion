using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
{
    public void Configure(EntityTypeBuilder<Profesor> builder)
    {
        builder.ToTable("profesor");

        builder.HasOne(p => p.Departamento)
        .WithMany(p => p.Profesores)
        .HasForeignKey(p => p.IdDepartamentoFk);

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.Profesores)
        .HasForeignKey(p => p.IdPersonaFk);
    }
}