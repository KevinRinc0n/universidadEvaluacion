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
    }
}