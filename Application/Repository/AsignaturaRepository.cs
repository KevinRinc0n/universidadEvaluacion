using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignatura
{
    private readonly UniversityDbContext _context;

    public AsignaturaRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }
}