using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly UniversityDbContext _context;
    private IAlumnoMatriculaAsignatura _alumnoMatriculaAsignatura;
    private IAsignatura _asignatura;
    private ICursoEscolar _cursoEscolar;
    private IDepartamento _departamento;
    private IGrado _grado;
    private IPersona _persona;
    private IProfesor _profesor;
    private ISexo _sexo;
    private ITipoPersona _tipoPersona;
    private ITipoAsignatura _tipoAsignatura;


    public UnitOfWork(UniversityDbContext context)
    {
        _context = context;
    }

    public IAlumnoMatriculaAsignatura AlumnoMatriculaAsignaturas
    {
        get
        {
            if (_alumnoMatriculaAsignatura == null)
            {
                _alumnoMatriculaAsignatura = new AlumnoMatriculaAsignaturaRepository(_context);
            }
            return _alumnoMatriculaAsignatura;
        }
    }

    public IAsignatura Asignaturas
    {
        get
        {
            if (_asignatura == null)
            {
                _asignatura = new AsignaturaRepository(_context);
            }
            return _asignatura;
        }
    }

    public ICursoEscolar CursoEscolares
    {
        get
        {
            if (_cursoEscolar == null)
            {
                _cursoEscolar = new CursoEscolarRepository(_context);
            }
            return _cursoEscolar;
        }
    }

    public IDepartamento Departamentos
    {
        get
        {
            if (_departamento == null)
            {
                _departamento = new DepartamentoRepository(_context);
            }
            return _departamento;
        }
    }

    public IGrado Grados
    {
        get
        {
            if (_grado == null)
            {
                _grado = new GradoRepository(_context);
            }
            return _grado;
        }
    }

    public IPersona Personas
    {
        get
        {
            if (_persona == null)
            {
                _persona = new PersonaRepository(_context);
            }
            return _persona;
        }
    }

    public IProfesor Profesores
    {
        get
        {
            if (_profesor == null)
            {
                _profesor = new ProfesorRepository(_context);
            }
            return _profesor;
        }
    }

    public ISexo Sexos
    {
        get
        {
            if (_sexo == null)
            {
                _sexo = new SexoRepository(_context);
            }
            return _sexo;
        }
    }

    public ITipoPersona TipoPersonas
    {
        get
        {
            if (_tipoPersona == null)
            {
                _tipoPersona = new TipoPersonaRepository(_context);
            }
            return _tipoPersona;
        }
    }

    public ITipoAsignatura TipoAsignaturas
    {
        get
        {
            if (_tipoAsignatura == null)
            {
                _tipoAsignatura = new TipoAsignaturaRepository(_context);
            }
            return _tipoAsignatura;
        }
    }
    

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}