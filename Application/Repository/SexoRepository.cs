using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class SexoRepository : GenericRepository<Sexo>, ISexo
{
    private readonly UniversityDbContext _context;

    public SexoRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }
}