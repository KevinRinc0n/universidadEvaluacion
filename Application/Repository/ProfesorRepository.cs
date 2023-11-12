using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class ProfesorRepository : GenericRepository<Profesor>, IProfesor
{
    private readonly UniversityDbContext _context;

    public ProfesorRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Profesor>> DepartamentoProfesores()
    {
        var departamentoProf = await _context.Profesores
            .Include(d => d.Departamento)
            .Include(d => d.Persona)
            .ToListAsync();

        return departamentoProf;
    }

    public async Task<IEnumerable<Profesor>> ProfesoresSinDepartamento()
    {
        var profesoresSinDepartamento = await _context.Profesores
            .Where(p => p.IdDepartamentoFk == null)
            .Include(p => p.Departamento)
            .Include(p => p.Persona)
            .ToListAsync();

        return profesoresSinDepartamento;
    }

    public async Task<IEnumerable<Profesor>> ProfesoresSinAsignatura()
    {
        var profesoresSinAsignatura = await _context.Profesores
            .Where(p => p.Asignaturas == null)
            .Include(p => p.Persona)  
            .ToListAsync();

        return profesoresSinAsignatura;
    }

    public async Task<IActionResult> AsignaturasXProfesor()
    {
        var resultado = await (
            from profesor in _context.Profesores
            join asignatura in _context.Asignaturas on profesor.Id equals asignatura.IdProfesorFk into asignaturasGroup
            select new
            {
                Profesor = profesor.Persona,
                NumeroAsignaturas = asignaturasGroup.Count()
            })
            .OrderByDescending(x => x.NumeroAsignaturas)
            .Select(x => new
            {
                Id = x.Profesor.Id,
                Nombre = x.Profesor.Nombre,
                PrimerApellido = x.Profesor.PrimerApellido,
                SegundoApellido = x.Profesor.SegundoApellido,
                NumeroAsignaturas = x.NumeroAsignaturas
            })
            .ToListAsync();

        return new OkObjectResult(resultado);
    }

    public async Task<IEnumerable<Profesor>> ProfesoresSinDep()
    {
        var departamentoProf = await _context.Profesores
            .Where(d => d.IdDepartamentoFk == null)
            .Include(d => d.Departamento)
            .Include(d => d.Persona)
            .ToListAsync();

        return departamentoProf;
    }

    public async Task<IEnumerable<Profesor>> ProfesoresDepSinAsignatura()
    {
        var profesoresSinAsignatura = await _context.Profesores
            .Include(p => p.Persona)
            .Include(p => p.Departamento)
            .Where(p => !p.Asignaturas.Any())  
            .ToListAsync();

        return profesoresSinAsignatura;
    }
}