namespace ApiUniversidad.Dtos;

public class ProfeSinAsingDto
{
    public PersonaDto PersonaDto { get; set; }
    public ICollection<AsignaturaSinDto> Asignaturas { get; set; }
}