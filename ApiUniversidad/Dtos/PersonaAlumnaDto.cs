namespace ApiUniversidad.Dtos;

public class PersonaAlumnaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public SexoDto Sexo { get; set; }
    public ICollection<AlumnoMatriculaAsignaturaDto> AlumnoMatriculaAsignaturas { get; set; }
}