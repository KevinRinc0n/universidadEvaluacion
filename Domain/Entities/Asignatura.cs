namespace Domain.Entities;

public class Asignatura : BaseEntity
{
    public string Nombre { get; set; }
    public float Creditos { get; set; }
    public int IdTipoAsignaturaFk { get; set; }
    public TipoAsignatura TipoAsignatura { get; set; }
    public int Curso { get; set; }
    public int Cuatrimestre { get; set; }
    public int? IdProfesorFk { get; set; }
    public Profesor Profesor { get; set; }
    public int IdGradoFk { get; set; }
    public Grado Grado { get; set; }
    public ICollection<AlumnoMatriculaAsignatura> AlumnoMatriculaAsignaturas { get; set; }
    public ICollection<Persona> Personas { get; set; }
    public ICollection<CursoEscolar> CursosEscolares { get; set; }
}