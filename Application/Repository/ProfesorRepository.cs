using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class ProfesorRepository : GenericRepository<Profesor>, IProfesor
{
    private readonly UniversityDbContext _context;

    public ProfesorRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }
}