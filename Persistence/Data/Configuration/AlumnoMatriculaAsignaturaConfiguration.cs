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
            .HasOne(am => am.Persona)
            .WithMany(p => p.AlumnoMatriculaAsignaturas)
            .HasForeignKey(am => am.IdAlumnoFk);

        builder
            .HasOne(am => am.CursoEscolar)
            .WithMany(c => c.AlumnoMatriculaAsignaturas)
            .HasForeignKey(am => am.IdCursoEscolarFk);

        builder
            .HasOne(am => am.Asignatura)
            .WithMany(a => a.AlumnoMatriculaAsignaturas)
            .HasForeignKey(am => am.IdAsignaturaFk);

        builder
            .HasKey(am => new { am.IdAlumnoFk, am.IdCursoEscolarFk, am.IdAsignaturaFk });

        builder.HasData(
            new AlumnoMatriculaAsignatura {Id = 1, IdAlumnoFk = 1, IdAsignaturaFk = 1, IdCursoEscolarFk = 1 },
            new AlumnoMatriculaAsignatura {Id = 2, IdAlumnoFk = 1, IdAsignaturaFk = 2, IdCursoEscolarFk = 1 },
            new AlumnoMatriculaAsignatura {Id = 3, IdAlumnoFk = 1, IdAsignaturaFk = 3, IdCursoEscolarFk = 1 },
            new AlumnoMatriculaAsignatura {Id = 4, IdAlumnoFk = 2, IdAsignaturaFk = 1, IdCursoEscolarFk = 1 },
            new AlumnoMatriculaAsignatura {Id = 5, IdAlumnoFk = 2, IdAsignaturaFk = 2, IdCursoEscolarFk = 1 },
            new AlumnoMatriculaAsignatura {Id = 6, IdAlumnoFk = 2, IdAsignaturaFk = 3, IdCursoEscolarFk = 1 },
            new AlumnoMatriculaAsignatura {Id = 7, IdAlumnoFk = 4, IdAsignaturaFk = 1, IdCursoEscolarFk = 1 },
            new AlumnoMatriculaAsignatura {Id = 8, IdAlumnoFk = 4, IdAsignaturaFk = 2, IdCursoEscolarFk = 1 },
            new AlumnoMatriculaAsignatura {Id = 9, IdAlumnoFk = 4, IdAsignaturaFk = 3, IdCursoEscolarFk = 1 },
            new AlumnoMatriculaAsignatura {Id = 10, IdAlumnoFk = 24, IdAsignaturaFk = 1, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 11, IdAlumnoFk = 24, IdAsignaturaFk = 2, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 12, IdAlumnoFk = 24, IdAsignaturaFk = 3, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 13, IdAlumnoFk = 24, IdAsignaturaFk = 4, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 14, IdAlumnoFk = 24, IdAsignaturaFk = 5, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 15, IdAlumnoFk = 24, IdAsignaturaFk = 6, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 16, IdAlumnoFk = 24, IdAsignaturaFk = 7, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 17, IdAlumnoFk = 24, IdAsignaturaFk = 8, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 18, IdAlumnoFk = 24, IdAsignaturaFk = 9, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 19, IdAlumnoFk = 24, IdAsignaturaFk = 10, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 20, IdAlumnoFk = 23, IdAsignaturaFk = 1, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 21, IdAlumnoFk = 23, IdAsignaturaFk = 2, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 22, IdAlumnoFk = 23, IdAsignaturaFk = 3, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 23, IdAlumnoFk = 23, IdAsignaturaFk = 4, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 24, IdAlumnoFk = 23, IdAsignaturaFk = 5, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 25, IdAlumnoFk = 23, IdAsignaturaFk = 6, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 26, IdAlumnoFk = 23, IdAsignaturaFk = 7, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 27, IdAlumnoFk = 23, IdAsignaturaFk = 8, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 28, IdAlumnoFk = 23, IdAsignaturaFk = 9, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 29, IdAlumnoFk = 23, IdAsignaturaFk = 10, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 30, IdAlumnoFk = 19, IdAsignaturaFk = 1, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 31, IdAlumnoFk = 19, IdAsignaturaFk = 2, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 32, IdAlumnoFk = 19, IdAsignaturaFk = 3, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 33, IdAlumnoFk = 19, IdAsignaturaFk = 4, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 34, IdAlumnoFk = 19, IdAsignaturaFk = 5, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 35, IdAlumnoFk = 19, IdAsignaturaFk = 6, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 36, IdAlumnoFk = 19, IdAsignaturaFk = 7, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 37, IdAlumnoFk = 19, IdAsignaturaFk = 8, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 38, IdAlumnoFk = 19, IdAsignaturaFk = 9, IdCursoEscolarFk = 5 },
            new AlumnoMatriculaAsignatura {Id = 39, IdAlumnoFk = 19, IdAsignaturaFk = 10, IdCursoEscolarFk = 5 }
        );    
    }
}