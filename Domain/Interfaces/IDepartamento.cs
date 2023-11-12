using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces;

public interface IDepartamento : IGenericRepository<Departamento>
{
    Task<IEnumerable<Departamento>> DepartamentoProfeInforma();
    Task<IEnumerable<Departamento>> AsignaturaSinCurso();
    Task<IActionResult> ProfesoresXDepP();
    Task<IEnumerable<Departamento>> DepSinProfes();
    Task<IEnumerable<Departamento>> DepartamentosSinAsignaturas();
}