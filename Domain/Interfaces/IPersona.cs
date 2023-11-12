using Domain.Entities;

namespace Domain.Interfaces;

public interface IPersona : IGenericRepository<Persona>
{
    Task<IEnumerable<Persona>> AlumnosMenorMayor();
    Task<IEnumerable<Persona>> AlumnosSinNumero();
    Task<IEnumerable<Persona>> Alumnos1999();
    Task<IEnumerable<Persona>> ProfesoresSinNumero();
    Task<IEnumerable<Persona>> AlumnasInformatica();
    Task<IEnumerable<Persona>> ProfesorDepartamento();
    Task<IEnumerable<Persona>> AlumnosMatriculados();
    Task<string> TotalAlumnas();
    Task<string> AlumnosNacieron1999();
    Task<Persona> AlumnoMasJoven();
}