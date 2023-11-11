namespace Domain.Entities;

public class CursoEscolar : BaseEntity
{
    public int AnoInicio { get; set; }
    public int AnoFin { get; set; }
    public ICollection<AlumnoMatriculaAsignatura> AlumnoMatriculaAsignaturas { get; set; }
    public ICollection<Persona> Personas { get; set; }
    public ICollection<Asignatura> Asignaturas { get; set; }
}