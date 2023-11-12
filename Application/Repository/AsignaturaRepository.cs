using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignatura
{
    private readonly UniversityDbContext _context;

    public AsignaturaRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Asignatura>> AsignaturasInformatica()
    {
        var asignaturaInformatica = await _context.Asignaturas
            .Where(p => p.IdGradoFk == 4)
            .Include(p => p.Grado)
            .ToListAsync();

        return asignaturaInformatica;
    }

    public async Task<IEnumerable<Asignatura>> AsignaturasAlumnoM()
    {
        var asignaturas = await _context.Personas
            .Where(p => p.Nif == "26902806M")
            .SelectMany(p => p.AlumnoMatriculaAsignaturas)
            .Select(ama => new
            {
                Asignatura = ama.Asignatura,
                CursoEscolar = ama.CursoEscolar
            })
            .ToListAsync();

        return asignaturas.Select(a => a.Asignatura).ToList();
    }

    public async Task<IEnumerable<Asignatura>> ProfesoresSinAsignatura()
    {
        var profesoresSinAsignatura = await _context.Asignaturas
            .Where(p => p.IdProfesorFk == null)
            .Include(p => p.Profesor) 
            .ThenInclude(p => p.Persona)  
            .ToListAsync();

        return profesoresSinAsignatura;
    }

    public async Task<IEnumerable<Asignatura>> AsignaturaSinProfe()
    {
        var AsignaturaNoProfe = await _context.Asignaturas
            .Where(a => a.IdProfesorFk == null)
            .ToListAsync();

        return AsignaturaNoProfe;
    }
}