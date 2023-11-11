using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Configuration;

namespace Persistence.Data;

public class UniversityDbContext : DbContext
{
    public UniversityDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<AlumnoMatriculaAsignatura> AlumnoMatriculaAsignaturas { get; set; }
    public DbSet<Asignatura> Asignaturas { get; set; }
    public DbSet<CursoEscolar> CursosEscolares { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Grado> Grados { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Profesor> Profesores { get; set; }
    public DbSet<Sexo> Sexos { get; set; }
    public DbSet<TipoPersona> TipoPersonas { get; set; }
    public DbSet<TipoAsignatura> TipoAsignaturas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}