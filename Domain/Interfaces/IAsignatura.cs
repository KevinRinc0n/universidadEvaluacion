using Domain.Entities;

namespace Domain.Interfaces;

public interface IAsignatura : IGenericRepository<Asignatura>
{
    Task<IEnumerable<Asignatura>> AsignaturasInformatica();
    Task<IEnumerable<Asignatura>> AsignaturasAlumnoM();
    Task<IEnumerable<Asignatura>> ProfesoresSinAsignatura();
    Task<IEnumerable<Asignatura>> AsignaturaSinProfe();
}