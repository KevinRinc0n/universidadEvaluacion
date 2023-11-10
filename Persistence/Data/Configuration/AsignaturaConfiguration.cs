using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
{
    public void Configure(EntityTypeBuilder<Asignatura> builder)
    {
        builder.ToTable("asignatura");

        builder.Property(x => x.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Creditos)
        .HasColumnType("float")
        .IsRequired();

        builder.Property(x => x.Curso)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(x => x.Cuatrimestre)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(x => x.IdProfesorFk)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(x => x.IdGradoFk) 
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Grado)
        .WithMany(p => p.Asignaturas)
        .HasForeignKey(p => p.IdGradoFk);

        builder.HasOne(p => p.Profesor)
        .WithMany(p => p.Asignaturas)
        .HasForeignKey(p => p.IdProfesorFk);
    }
}