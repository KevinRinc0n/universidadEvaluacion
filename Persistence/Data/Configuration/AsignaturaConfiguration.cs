using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
{
    public void Configure(EntityTypeBuilder<Asignatura> builder)
    {
        builder.ToTable("asignatura");

        builder.Property(x => x.Nombre)
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(x => x.Creditos)
        .HasColumnType("float")
        .IsRequired();

        builder.Property(x => x.Curso)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(x => x.Cuatrimestre)
        .HasColumnType("int")
        .IsRequired();

        builder.Property(x => x.IdProfesorFk)
        .HasColumnType("int");

        builder.Property(x => x.IdGradoFk) 
        .HasColumnType("int")
        .IsRequired();

        builder.HasOne(p => p.Grado)
        .WithMany(p => p.Asignaturas)
        .HasForeignKey(p => p.IdGradoFk);

        builder.HasOne(p => p.Profesor)
        .WithMany(p => p.Asignaturas)
        .HasForeignKey(p => p.IdProfesorFk);

        builder.HasOne(p => p.TipoAsignatura)
        .WithMany(p => p.Asignaturas)
        .HasForeignKey(p => p.IdTipoAsignaturaFk);

        builder.HasData(
            new Asignatura { Id = 1, Nombre = "Algegra lineal y matematica discreta", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 1, IdProfesorFk = 3, IdGradoFk = 4},
            new Asignatura { Id = 2, Nombre = "Calculo", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 1, IdProfesorFk = 14, IdGradoFk = 4 },
            new Asignatura { Id = 3, Nombre = "Fisica para informatica", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 1, IdProfesorFk = 3, IdGradoFk = 4 },
            new Asignatura { Id = 4, Nombre = "Introduccion a la programacion", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 1, IdProfesorFk = 14, IdGradoFk = 4 },
            new Asignatura { Id = 5, Nombre = "Organizacion y gestion de empresas", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 1, IdProfesorFk = 3, IdGradoFk = 4 },
            new Asignatura { Id = 6, Nombre = "Estadistica", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 2, IdProfesorFk = 14, IdGradoFk = 4 },
            new Asignatura { Id = 7, Nombre = "Estructura y tecnologia de computadores", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 2, IdProfesorFk = 3, IdGradoFk = 4 },
            new Asignatura { Id = 8, Nombre = "Fundamentos de electronica", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 2, IdProfesorFk = 14, IdGradoFk = 4 },
            new Asignatura { Id = 9, Nombre = "Logica y algoritmica", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 2, IdProfesorFk = 3, IdGradoFk = 4 },
            new Asignatura { Id = 10, Nombre = "Metodologia de la programacion", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 2, IdProfesorFk = 14, IdGradoFk = 4 },
            new Asignatura { Id = 11, Nombre = "Arquitectura de Computadores", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 2, Cuatrimestre = 1, IdProfesorFk = 3, IdGradoFk = 4 },
            new Asignatura { Id = 12, Nombre = "Estructura de Datos y Algoritmos I", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 1, IdProfesorFk = 3, IdGradoFk = 4 },
            new Asignatura { Id = 13, Nombre = "Ingenieria del Software", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 1, IdProfesorFk = 14, IdGradoFk = 4 },
            new Asignatura { Id = 14, Nombre = "Sistemas Inteligentes", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 1, IdProfesorFk = 3, IdGradoFk = 4 },
            new Asignatura { Id = 15, Nombre = "Sistemas Operativos", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 1, IdProfesorFk = 14, IdGradoFk = 4 },
            new Asignatura { Id = 16, Nombre = "Bases de Datos", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 2, Cuatrimestre = 2, IdProfesorFk = 14, IdGradoFk = 4 },
            new Asignatura { Id = 17, Nombre = "Estructura de Datos y Algoritmos II", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 2, IdProfesorFk = 14, IdGradoFk = 4 },
            new Asignatura { Id = 18, Nombre = "Fundamentos de Redes de Computadores", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 2, IdProfesorFk = 3, IdGradoFk = 4 },
            new Asignatura { Id = 19, Nombre = "Planificaciin y Gestiin de Proyectos Informaticos", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 2, IdProfesorFk = 3, IdGradoFk = 4 },
            new Asignatura { Id = 20, Nombre = "Programacion de Servicios Software", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 3, Cuatrimestre = 1, IdProfesorFk = 14, IdGradoFk = 4 },
            new Asignatura { Id = 21, Nombre = "Desarrollo de interfaces de usuario", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 3, Cuatrimestre = 1, IdProfesorFk = 14, IdGradoFk = 4 },
            new Asignatura { Id = 22, Nombre = "Ingenieria de Requisitos", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 23, Nombre = "Integracion de las Tecnologías de la Informacion en las Organizaciones", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 24, Nombre = "Modelado y Diseño del Software 1", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 25, Nombre = "Multiprocesadores", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 26, Nombre = "Seguridad y cumplimiento normativo", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 27, Nombre = "Sistema de Información para las Organizaciones", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 28, Nombre = "Tecnologias web", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 29, Nombre = "Teoria de codigos y criptografia", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 30, Nombre = "Administracion de bases de datos", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 31, Nombre = "Herramientas y Metodos de Ingeniería del Software", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 32, Nombre = "Informatica industrial y robotica", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 33, Nombre = "Ingenieria de Sistemas de Informacion", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 34, Nombre = "Modelado y Diseño del Software 2", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 35, Nombre = "Negocio Electronico", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 36, Nombre = "Perifericos e interfaces", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 37, Nombre = "Sistemas de tiempo real", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 38, Nombre = "Tecnologias de acceso a red", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 39, Nombre = "Tratamiento digital de imagenes", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 40, Nombre = "Administracion de redes y sistemas operativos", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 41, Nombre = "Almacenes de Datos", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 42, Nombre = "Fiabilidad y Gestión de Riesgos", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 43, Nombre = "Lineas de Productos Software", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 44, Nombre = "Procesos de Ingenieria del Software 1", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 45, Nombre = "Tecnologias multimedia", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 46, Nombre = "Analisis y planificación de las TI", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 47, Nombre = "Desarrollo Rapido de Aplicaciones", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 48, Nombre = "Gestion de la Calidad y de la Innovacion Tecnologica", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 49, Nombre = "Inteligencia del Negocio", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 50, Nombre = "Procesos de Ingenieria del Software 2", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 51, Nombre = "Seguridad Informatica", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 4, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 4 },
            new Asignatura { Id = 52, Nombre = "Biologia celular", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 53, Nombre = "Fisica", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 54, Nombre = "Matematicas I", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 55, Nombre = "Quimica general", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 56, Nombre = "Quimica organica", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 57, Nombre = "Biologia vegetal y animal", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 58, Nombre = "Bioquimica", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 59, Nombre = "Genetica", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 60, Nombre = "Matematicas II", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 61, Nombre = "Microbiologia", Creditos = 6, IdTipoAsignaturaFk = 1, Curso = 1, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 62, Nombre = "Botanica agricola", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 63, Nombre = "Fisiologia vegetal", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 64, Nombre = "Genetica molecular", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 65, Nombre = "Ingenieria bioquimica", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 66, Nombre = "Termodinamica y cinetica quimica aplicada", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 67, Nombre = "Biorreactores", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 68, Nombre = "Biotecnologia microbiana", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 69, Nombre = "Ingenieria genetica", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 70, Nombre = "Inmunologia", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 71, Nombre = "Virologia", Creditos = 6, IdTipoAsignaturaFk = 2, Curso = 2, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 72, Nombre = "Bases moleculares del desarrollo vegetal", Creditos = 4.5f, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 73, Nombre = "Fisiologia animal", Creditos = 4.5f, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 74, Nombre = "Metabolismo y biosintesis de biomoleculas", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 75, Nombre = "Operaciones de separacion", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 76, Nombre = "Patologia molecular de plantas", Creditos = 4.5f, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 1, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 78, Nombre = "Bioinformatica", Creditos = 4.5f, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 79, Nombre = "Biotecnologia de los productos hortofruticulas", Creditos = 4.5f, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 80, Nombre = "Biotecnologia vegetal", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 81, Nombre = "Genomica y proteomica", Creditos = 4.5f, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 82, Nombre = "Procesos biotecnologicos", Creditos = 6, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 },
            new Asignatura { Id = 83, Nombre = "Técnicas instrumentales avanzadas", Creditos = 4.5f, IdTipoAsignaturaFk = 3, Curso = 3, Cuatrimestre = 2, IdProfesorFk = null, IdGradoFk = 7 }
        );
    }
}