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

        builder.HasData(
            new Profesor { Id = 1, IdPersonaFk = 3, IdDepartamentoFk = 1},
            new Profesor { Id = 2, IdPersonaFk = 5, IdDepartamentoFk = 2},
            new Profesor { Id = 3, IdPersonaFk = 8, IdDepartamentoFk = 3},
            new Profesor { Id = 4, IdPersonaFk = 10, IdDepartamentoFk = 4},
            new Profesor { Id = 5, IdPersonaFk = 12, IdDepartamentoFk = 4},
            new Profesor { Id = 6, IdPersonaFk = 13, IdDepartamentoFk = 6},
            new Profesor { Id = 7, IdPersonaFk = 14, IdDepartamentoFk = 1},
            new Profesor { Id = 8, IdPersonaFk = 15, IdDepartamentoFk = 2},
            new Profesor { Id = 9, IdPersonaFk = 16, IdDepartamentoFk = 3},
            new Profesor { Id = 10, IdPersonaFk = 17, IdDepartamentoFk = 4},
            new Profesor { Id = 11, IdPersonaFk = 18, IdDepartamentoFk = 5},
            new Profesor { Id = 12, IdPersonaFk = 20, IdDepartamentoFk = 6},
            new Profesor { Id = 13, IdPersonaFk = 7, IdDepartamentoFk = 2},
            new Profesor { Id = 14, IdPersonaFk = 4, IdDepartamentoFk = 3}
        );
    }
}