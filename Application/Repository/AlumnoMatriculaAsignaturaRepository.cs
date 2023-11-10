using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class AlumnoMatriculaAsignaturaRepository : GenericRepository<AlumnoMatriculaAsignatura>, IAlumnoMatriculaAsignatura
{
    private readonly UniversityDbContext _context;

    public AlumnoMatriculaAsignaturaRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }
}