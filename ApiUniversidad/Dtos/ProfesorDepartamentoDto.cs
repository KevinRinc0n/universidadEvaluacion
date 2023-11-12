namespace ApiUniversidad.Dtos;

public class ProfesorDepartamentoDto
{
    public int Id { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string Nombre { get; set; }
    public ICollection<ProfesorDto> Profesores { get; set; }
}