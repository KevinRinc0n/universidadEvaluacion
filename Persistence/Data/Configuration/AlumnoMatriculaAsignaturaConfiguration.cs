using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class AlumnoMatriculaAsignaturaConfiguration : IEntityTypeConfiguration<AlumnoMatriculaAsignatura>
{
    public void Configure(EntityTypeBuilder<AlumnoMatriculaAsignatura> builder)
    {
        builder.ToTable("alumnoMatriculaAsignatura");

        builder
            .HasKey(a => new { a.IdCursoEscolarFk, a.IdAlumnoFk, a.IdAsignaturaFk });

        builder
            .HasOne(a => a.CursoEscolar)
            .WithMany(u => u.AlumnoMatriculaAsignaturas)
            .HasForeignKey(a => a.IdCursoEscolarFk);

        builder
            .HasOne(a => a.Asignatura)
            .WithMany(r => r.AlumnoMatriculaAsignaturas)
            .HasForeignKey(a => a.IdAsignaturaFk);

        builder
            .HasOne(a => a.Persona)
            .WithMany(rt => rt.AlumnoMatriculaAsignaturas)
            .HasForeignKey(a => a.IdAlumnoFk);
    }
}