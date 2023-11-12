using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly UniversityDbContext _context;

    public PersonaRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Persona>> AlumnosMenorMayor()
    {
        var menorAMayor = await _context.Personas
            .Where(m => m.IdTipoPersonaFk == 1)
            .OrderByDescending(m => m.PrimerApellido) 
            .ThenByDescending(m => m.SegundoApellido)
            .ThenByDescending(m => m.Nombre)
            .ToListAsync();

        return menorAMayor;
    }

    public async Task<IEnumerable<Persona>> AlumnosSinNumero()
    {
        var alumnosNoNumero = await _context.Personas
            .Where(m => m.IdTipoPersonaFk == 1 && m.Telefono == null)
            .ToListAsync();

        return alumnosNoNumero;
    }

    public async Task<IEnumerable<Persona>> Alumnos1999()
    {
        var alumnosNacidos1999 = await _context.Personas
            .Where(m => m.FechaNacimiento >= new DateTime(1999, 1, 1) && m.FechaNacimiento <= new DateTime(1999, 12, 31))
            .ToListAsync();

        return alumnosNacidos1999;
    }

    public async Task<IEnumerable<Persona>> ProfesoresSinNumero()
    {
        var profesoresNoNumero = await _context.Personas
            .Where(m => m.IdTipoPersonaFk == 2 && m.Telefono == null && m.Nif.EndsWith("K"))
            .ToListAsync();

        return profesoresNoNumero;
    }

    public async Task<IEnumerable<Persona>> AlumnasInformatica()
    {
        var alumnas = await _context.Personas
            .Where(p => p.IdTipoPersonaFk == 1 && p.IdSexoFk == 2)
            .Include(p => p.Sexo)
            .Include(p => p.AlumnoMatriculaAsignaturas)
            .ThenInclude(am => am.Asignatura)
            .ThenInclude(am => am.Grado)
            .Where(p => p.AlumnoMatriculaAsignaturas
                .Any(am => am.Asignatura.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)")
            )
            .Distinct()
            .ToListAsync();

        return alumnas;
    }

    public async Task<IEnumerable<Persona>> ProfesorDepartamento()
    {
        var profesorDep = await _context.Personas
            .Where(p => p.IdTipoPersonaFk == 2)
            .Include(p => p.Profesores)
            .ThenInclude(am => am.Departamento)
            .OrderByDescending(m => m.PrimerApellido) 
            .ThenByDescending(m => m.SegundoApellido)
            .ThenByDescending(m => m.Nombre)
            .ToListAsync();

        return profesorDep;
    }

    public async Task<IEnumerable<Persona>> AlumnosMatriculados()
    {
        var alumnosMatriculados = await _context.Personas
            .Where(m => m.IdTipoPersonaFk == 1)
            .Where(p => p.AlumnoMatriculaAsignaturas
                    .Any(m => m.CursoEscolar.AnoInicio == 2018 && m.CursoEscolar.AnoFin == 2019)) 
            .ToListAsync(); 

        return alumnosMatriculados;
    }

    public async Task<string> TotalAlumnas()
    {
        var totalAlumnas = await _context.Personas
            .Where(p => p.IdTipoPersonaFk == 1 && p.IdSexoFk == 2)
            .CountAsync();

        return "El numero total de alumnas es: "+ totalAlumnas;
    }

    public async Task<string> AlumnosNacieron1999()
    {
        var total1999 = await _context.Personas
            .Where(p => p.IdTipoPersonaFk == 1 && p.FechaNacimiento >= new DateTime(1999, 1, 1) && p.FechaNacimiento <= new DateTime(1999, 12, 31))
            .CountAsync();

        return "El numero total de alumnos que nacieron en 1999 es: "+ total1999;
    }

    public async Task<Persona> AlumnoMasJoven()
    {
        var alumnoMasJoven = await _context.Personas
            .Where(m => m.IdTipoPersonaFk == 1) 
            .OrderBy(m => m.FechaNacimiento)    
            .LastOrDefaultAsync();             

        return alumnoMasJoven;
    }
}