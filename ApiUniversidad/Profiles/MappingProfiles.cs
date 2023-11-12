using ApiUniversidad.Dtos;
using AutoMapper;
using Domain.Entities;

namespace ApiUniversidad.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Persona, PersonaDto>().ReverseMap();
        CreateMap<Persona, PersonaFechaDto>().ReverseMap();
        CreateMap<Persona, PersonaProfDto>().ReverseMap();
        CreateMap<Persona, PersonaAlumnaDto>().ReverseMap();
        CreateMap<Sexo, SexoDto>().ReverseMap();
        CreateMap<Grado, GradoDto>().ReverseMap();
        CreateMap<Asignatura, AsignaturaDto>().ReverseMap();
        CreateMap<AlumnoMatriculaAsignatura, AlumnoMatriculaAsignaturaDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Persona, ProfesorDepartamentoDto>().ReverseMap();
        CreateMap<Profesor, ProfesorDto>().ReverseMap();
        CreateMap<Profesor, ProfesorDepDto>().ReverseMap();
        CreateMap<AlumnoMatriculaAsignatura, AlumnoMatriculaAsignaturaCursoDto>().ReverseMap();
        CreateMap<Persona, PersonaMatriculadoDto>().ReverseMap();
        CreateMap<Profesor, ProfesorDeptoDto>().ReverseMap();
        CreateMap<Profesor, ProfesorPersonaDto>().ReverseMap();
        CreateMap<Asignatura, AsignaturaProfeDto>().ReverseMap();
        CreateMap<Profesor, ProfeSinAsingDto>().ReverseMap();
        CreateMap<Asignatura, AsignaturaSinDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoAsignaturaDto>().ReverseMap();
        CreateMap<Persona, PersoAlumMasJovenDto>().ReverseMap();
    }
}
