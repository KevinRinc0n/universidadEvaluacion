namespace ApiUniversidad.Dtos;

public class PersonaMatriculadoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public ICollection<AlumnoMatriculaAsignaturaCursoDto> AlumnoMatriculaAsignaturaCurso { get; set; }
}