using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    private readonly UniversityDbContext _context;

    public DepartamentoRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Departamento>> DepartamentoProfeInforma()
    {
        var departamentoInformatica = await _context.Departamentos
            .Where(d => d.Profesores.Any(p => p.Persona.IdTipoPersonaFk == 2 && p.Asignaturas.Any(a => a.IdGradoFk == 4)))
            .ToListAsync();

        return departamentoInformatica;
    }

    public async Task<IEnumerable<Departamento>> AsignaturaSinCurso()
    {
        var departamentosConAsignaturaSinCurso = await _context.Departamentos
            .Where(departamento =>
                departamento.Profesores.Any(profesor =>
                    profesor.Asignaturas.Any(asignatura =>
                        asignatura.AlumnoMatriculaAsignaturas.All(matricula => matricula.CursoEscolar == null)
                    )
                )
            )
            .ToListAsync();

        return departamentosConAsignaturaSinCurso;
    }

    public async Task<IActionResult> ProfesoresXDepP()
    {
        var resultado = await _context.Departamentos
            .GroupJoin(
                _context.Profesores,
                d => d.Id,
                p => p.IdDepartamentoFk,
                (departamento, profesores) => new
                {
                    Departamento = departamento,
                    NumeroProfesores = profesores.Count()
                })
            .Select(x => new
            {
                Departamento = x.Departamento,
                NumeroProfesores = x.NumeroProfesores
            })
            .ToListAsync();

        return new OkObjectResult(resultado);
    }

    public async Task<IEnumerable<Departamento>> DepSinProfes()
    {
        var departamentosSinProfesores = await _context.Departamentos
            .Where(d => d.Profesores == null || !d.Profesores.Any())
            .ToListAsync();

        return departamentosSinProfesores;
    }

    public async Task<IEnumerable<Departamento>> DepartamentosSinAsignaturas()
    {
        var departamentosSinAsignaturas = await _context.Departamentos
            .Where(d => !d.Profesores.Any(p => p.Asignaturas.Any()))
            .ToListAsync();

        return departamentosSinAsignaturas;
    }
}