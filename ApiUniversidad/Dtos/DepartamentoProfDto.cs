namespace ApiUniversidad.Dtos;

public class DepartamentoProfDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<ProfesorDepDto> Profesores { get; set; }
}