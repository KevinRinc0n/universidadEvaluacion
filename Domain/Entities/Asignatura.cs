namespace Domain.Entities;

public class Asignatura : BaseEntity
{
    public string Nombre { get; set; }
    public float Creditos { get; set; }
    public enum Tipo { Basica, Obligatoria}
    public int Curos { get; set; }
    public int Cuatrimestre { get; set; }
    public int IdProfesorFk { get; set; }
    public Profesor Profesor { get; set; }
    public int IdGradoFk { get; set; }
    public Grado Grado { get; set; }
    public ICollection<AlumnoMatriculaAsignatura> AlumnoMatriculaAsignaturas { get; set; }
}