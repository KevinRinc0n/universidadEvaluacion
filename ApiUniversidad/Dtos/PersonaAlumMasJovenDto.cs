namespace ApiUniversidad.Dtos;

public class PersoAlumMasJovenDto
{
    public int Id { get; set; }
    public string Nif { get; set; }
    public string Nombre { get; set; }
    public string PrimerApellido { get; set; }
    public string SegundoApellido { get; set; }
    public string Ciudad { get; set; }
    public string Direccion { get; set; }
    public string? Telefono { get; set; }
    public DateTime FechaNacimiento { get; set; }
}