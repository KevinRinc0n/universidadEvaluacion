using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class TipoAsignaturaRepository : GenericRepository<TipoAsignatura>, ITipoAsignatura
{
    private readonly UniversityDbContext _context;

    public TipoAsignaturaRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }
}