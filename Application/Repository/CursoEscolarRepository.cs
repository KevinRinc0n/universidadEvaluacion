using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class CursoEscolarRepository : GenericRepository<CursoEscolar>, ICursoEscolar
{
    private readonly UniversityDbContext _context;

    public CursoEscolarRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }
}