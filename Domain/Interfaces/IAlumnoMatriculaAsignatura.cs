using Domain.Entities;

namespace Domain.Interfaces;

public interface IAlumnoMatriculaAsignatura : IGenericRepository<AlumnoMatriculaAsignatura>
{
    Task<IEnumerable<object>> AlumnosMatriculados();
}