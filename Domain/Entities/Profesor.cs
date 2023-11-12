namespace Domain.Entities;

public class Profesor : BaseEntity
{
    public int? IdDepartamentoFk { get; set; }
    public Departamento Departamento { get; set; }
    public int IdPersonaFk { get; set; }
    public Persona Persona { get; set; }
    public ICollection<Asignatura> Asignaturas { get; set; }
}