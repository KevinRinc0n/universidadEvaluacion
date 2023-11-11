using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersona
{
    private readonly UniversityDbContext _context;

    public TipoPersonaRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }
}