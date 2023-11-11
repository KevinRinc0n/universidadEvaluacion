using System.Security.AccessControl;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class CursoEscolarConfiguration : IEntityTypeConfiguration<CursoEscolar>
{
    public void Configure(EntityTypeBuilder<CursoEscolar> builder)
    {
        builder.ToTable("cursoEscolar");

        builder.Property(x => x.AnoInicio)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(x => x.AnoFin)
        .HasColumnType("int")
        .IsRequired();

        builder.HasData(
            new CursoEscolar { Id = 1, AnoFin = 2014, AnoInicio = 2015},
            new CursoEscolar { Id = 2, AnoFin = 2015, AnoInicio = 2016},
            new CursoEscolar { Id = 3, AnoFin = 2016, AnoInicio = 2017},
            new CursoEscolar { Id = 4, AnoFin = 2017, AnoInicio = 2018},
            new CursoEscolar { Id = 5, AnoFin = 2018, AnoInicio = 2019}
        );
    }
}