using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class AlumnoMatriculaAsignaturaRepository : GenericRepository<AlumnoMatriculaAsignatura>, IAlumnoMatriculaAsignatura
{
    private readonly UniversityDbContext _context;

    public AlumnoMatriculaAsignaturaRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> AlumnosMatriculados()
    {
        var resultado = await _context.AlumnoMatriculaAsignaturas
            .Include(am => am.CursoEscolar)
            .GroupBy(am => new { am.CursoEscolar.AnoInicio })
            .Select(g => new
            {
                AnoInicioCurso = g.Key.AnoInicio,
                NumeroAlumnosMatriculados = g.Count()
            })
            .ToListAsync();

        return resultado;
    }
}