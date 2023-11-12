namespace ApiUniversidad.Dtos;

public class ProfesorDeptoDto
{
    public int Id { get; set; }
    public PersonaDto Persona { get; set; }
    public DepartamentoDto Departamento { get; set; }
}