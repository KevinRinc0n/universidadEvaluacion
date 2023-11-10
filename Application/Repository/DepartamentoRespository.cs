using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    private readonly UniversityDbContext _context;

    public DepartamentoRepository(UniversityDbContext context) : base(context)
    {
        _context = context;
    }
}