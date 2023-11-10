using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class GradoRepository : GenericRepository<Grado>, IGrado
{
    private readonly UniversityDbContext _context;

    public GradoRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }
}