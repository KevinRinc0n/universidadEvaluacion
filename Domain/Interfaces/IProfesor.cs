using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces;

public interface IProfesor : IGenericRepository<Profesor>
{
    Task<IEnumerable<Profesor>> DepartamentoProfesores();
    Task<IEnumerable<Profesor>> ProfesoresSinDepartamento();
    Task<IEnumerable<Profesor>> ProfesoresSinAsignatura();
    Task<IActionResult> AsignaturasXProfesor();
    Task<IEnumerable<Profesor>> ProfesoresSinDep();
    Task<IEnumerable<Profesor>> ProfesoresDepSinAsignatura();
}