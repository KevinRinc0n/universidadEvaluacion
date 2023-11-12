namespace ApiUniversidad.Dtos;

public class AsignaturaProfeDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ProfesorPersonaDto Profesor { get; set; }
}
