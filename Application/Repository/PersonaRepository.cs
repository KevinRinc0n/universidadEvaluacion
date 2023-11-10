using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly UniversityDbContext _context;

    public PersonaRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }
}