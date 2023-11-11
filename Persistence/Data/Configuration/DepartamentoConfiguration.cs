using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");

        builder.Property(x => x.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.HasData(
            new Departamento { Id = 1, Nombre = "Informatica"},
            new Departamento { Id = 2, Nombre = "Matematicas"},
            new Departamento { Id = 3, Nombre = "Economia y Empresa"},
            new Departamento { Id = 4, Nombre = "Educacion"},
            new Departamento { Id = 5, Nombre = "Agronomia"},
            new Departamento { Id = 6, Nombre = "Quimica y Fisica"},
            new Departamento { Id = 7, Nombre = "Filologia"},
            new Departamento { Id = 8, Nombre = "Derecho"},
            new Departamento { Id = 9, Nombre = "Biologia y Geologia"}
        );
    }
}