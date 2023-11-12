using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class GradoRepository : GenericRepository<Grado>, IGrado
{
    private readonly UniversityDbContext _context;

    public GradoRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IActionResult> asignaturasXGrados()
    {
        var resultado = await _context.Grados
            .GroupJoin(
                _context.Asignaturas,
                d => d.Id,
                p => p.IdGradoFk,
                (grado, asignaturas) => new
                {
                    Grado = grado,
                    NumeroAsignaturas = asignaturas.Count()
                })
            .OrderByDescending(x => x.NumeroAsignaturas)
            .Select(x => new
            {
                Grado = x.Grado,
                NumeroAsignaturas = x.NumeroAsignaturas
            })
            .ToListAsync();

        return new OkObjectResult(resultado);
    }

    public async Task<IActionResult> AsignaturasXGrados40()
    {
        var resultado = await _context.Grados
            .GroupJoin(
                _context.Asignaturas,
                grado => grado.Id,
                asignatura => asignatura.IdGradoFk,
                (grado, asignaturas) => new
                {
                    Grado = grado,
                    Asignaturas = asignaturas.ToList() 
                })
            .Where(x => x.Asignaturas.Count > 40)
            .OrderByDescending(x => x.Asignaturas.Count)
            .Select(x => new
            {
                Grado = x.Grado.Nombre,
                NumeroAsignaturas = x.Asignaturas.Count
            })
            .ToListAsync();

        return new OkObjectResult(resultado);
    }

    public async Task<IEnumerable<Grado>> AlumnosMatriculados()
    {
        var alumnosMatriculados = await _context.Grados
            .Include(m => m.Asignaturas)
            .ToListAsync(); 

        return alumnosMatriculados;
    }
}