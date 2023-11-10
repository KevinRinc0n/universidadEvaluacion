namespace Domain.Entities;

public class Persona : BaseEntity
{
    public string Nif { get; set; }
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string Ciudad { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public enum Sexo { H, M }
    public enum Tipo { Alumno, Profesor }
    public ICollection<Profesor> Profesores { get; set; }
    public ICollection<AlumnoMatriculaAsignatura> AlumnoMatriculaAsignaturas { get; set; }
}