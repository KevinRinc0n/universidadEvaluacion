namespace ApiUniversidad.Dtos;

public class AsignaturaMDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public CursoEscolarDto Curso { get; set; }
}