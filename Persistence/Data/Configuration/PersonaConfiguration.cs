using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.Property(x => x.Nif)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.PrimerApellido)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.SegundoApellido)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Ciudad)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Direccion)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Telefono)
        .HasMaxLength(50);

        builder.Property(x => x.FechaNacimiento)
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(p => p.Sexo)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdSexoFk);

        builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdTipoPersonaFk);

        builder.HasData(
            new Persona { Id = 1, Nif = "26902806M", Nombre = "Salvador", PrimerApellido = "Sanchez", SegundoApellido = "Perez", Ciudad = "Almeria", Direccion = "C/ Real del barrio alto", Telefono = "950254837", FechaNacimiento = DateTime.Parse("1991-03-28"), IdSexoFk = 1, IdTipoPersonaFk = 1},
            new Persona { Id = 2, Nif = "89542419S", Nombre = "Juan", PrimerApellido = "Saez", SegundoApellido = "Vega", Ciudad = "Almería", Direccion = "C/ Mercurio", Telefono = "618253876", FechaNacimiento = DateTime.Parse("1992-08-08"), IdSexoFk = 1, IdTipoPersonaFk = 1 },
            new Persona { Id = 3, Nif = "11105554G", Nombre = "Zoe", PrimerApellido = "Ramirez", SegundoApellido = "Gea", Ciudad = "Almería", Direccion = "C/ Marte", Telefono = "618223876", FechaNacimiento = DateTime.Parse("1979-08-19"), IdSexoFk = 2, IdTipoPersonaFk = 2 },
            new Persona { Id = 4, Nif = "17105885A", Nombre = "Pedro", PrimerApellido = "Heller", SegundoApellido = "Pagac", Ciudad = "Almería", Direccion = "C/ Estrella fugaz", Telefono = null, FechaNacimiento = DateTime.Parse("2000-10-05"), IdSexoFk = 1, IdTipoPersonaFk = 1 },
            new Persona { Id = 5, Nif = "38223286T", Nombre = "David", PrimerApellido = "Schmidt", SegundoApellido = "Fisher", Ciudad = "Almería", Direccion = "C/ Venus", Telefono = "678516294", FechaNacimiento = DateTime.Parse("1978-01-19"), IdSexoFk = 1, IdTipoPersonaFk = 2 },
            new Persona { Id = 6, Nif = "04233869Y", Nombre = "José", PrimerApellido = "Koss", SegundoApellido = "Bayer", Ciudad = "Almería", Direccion = "C/ Júpiter", Telefono = "628349590", FechaNacimiento = DateTime.Parse("1998-01-28"), IdSexoFk = 1, IdTipoPersonaFk = 1 },
            new Persona { Id = 7, Nif = "97258166K", Nombre = "Ismael", PrimerApellido = "Strosin", SegundoApellido = "Turcotte", Ciudad = "Almería", Direccion = "C/ Neptuno", Telefono = null, FechaNacimiento = DateTime.Parse("1999-05-24"), IdSexoFk = 1, IdTipoPersonaFk = 1 },
            new Persona { Id = 8, Nif = "79503962T", Nombre = "Cristina", PrimerApellido = "Lemke", SegundoApellido = "Rutherford", Ciudad = "Almería", Direccion = "C/ Saturno", Telefono = "669162534", FechaNacimiento = DateTime.Parse("1977-08-21"), IdSexoFk = 2, IdTipoPersonaFk = 2 },
            new Persona { Id = 9, Nif = "82842571K", Nombre = "Ramón", PrimerApellido = "Herzog", SegundoApellido = "Tremblay", Ciudad = "Almería", Direccion = "C/ Urano", Telefono = "626351429", FechaNacimiento = DateTime.Parse("1996-11-21"), IdSexoFk = 1, IdTipoPersonaFk = 1 },
            new Persona { Id = 10, Nif = "61142000L", Nombre = "Esther", PrimerApellido = "Spencer", SegundoApellido = "Lakin", Ciudad = "Almería", Direccion = "C/ Plutón", Telefono = null, FechaNacimiento = DateTime.Parse("1977-05-19"), IdSexoFk = 2, IdTipoPersonaFk = 2 },
            new Persona { Id = 11, Nif = "46900725E", Nombre = "Daniel", PrimerApellido = "Herman", SegundoApellido = "Pacocha", Ciudad = "Almería", Direccion = "C/ Andarax", Telefono = "679837625", FechaNacimiento = DateTime.Parse("1997-04-26"), IdSexoFk = 1, IdTipoPersonaFk = 1 },
            new Persona { Id = 12, Nif = "85366986W", Nombre = "Carmen", PrimerApellido = "Streich", SegundoApellido = "Hirthe", Ciudad = "Almería", Direccion = "C/ Almanzora", Telefono = null, FechaNacimiento = DateTime.Parse("1971-04-29"), IdSexoFk = 2, IdTipoPersonaFk = 2 },
            new Persona { Id = 13, Nif = "73571384L", Nombre = "Alfredo", PrimerApellido = "Stiedemann", SegundoApellido = "Morissette", Ciudad = "Almería", Direccion = "C/ Guadalquivir", Telefono = "950896725", FechaNacimiento = DateTime.Parse("1980-02-01"), IdSexoFk = 1, IdTipoPersonaFk = 2 },
            new Persona { Id = 14, Nif = "82937751G", Nombre = "Manolo", PrimerApellido = "Hamill", SegundoApellido = "Kozey", Ciudad = "Almería", Direccion = "C/ Duero", Telefono = "950263514", FechaNacimiento = DateTime.Parse("1977-01-02"), IdSexoFk = 1, IdTipoPersonaFk = 2 },
            new Persona { Id = 15, Nif = "80502866Z", Nombre = "Alejandro", PrimerApellido = "Kohler", SegundoApellido = "Schoen", Ciudad = "Almería", Direccion = "C/ Tajo", Telefono = "668726354", FechaNacimiento = DateTime.Parse("1980-03-14"), IdSexoFk = 1, IdTipoPersonaFk = 2 },
            new Persona { Id = 16, Nif = "10485008K", Nombre = "Antonio", PrimerApellido = "Fahey", SegundoApellido = "Considine", Ciudad = "Almería", Direccion = "C/ Sierra de los Filabres", Telefono = null, FechaNacimiento = DateTime.Parse("1982-03-18"), IdSexoFk = 1, IdTipoPersonaFk = 2 },
            new Persona { Id = 17, Nif = "85869555K", Nombre = "Guillermo", PrimerApellido = "Ruecker", SegundoApellido = "Upton", Ciudad = "Almería", Direccion = "C/ Sierra de Gádor", Telefono = null, FechaNacimiento = DateTime.Parse("1973-05-05"), IdSexoFk = 1, IdTipoPersonaFk = 2 },
            new Persona { Id = 18, Nif = "04326833G", Nombre = "Micaela", PrimerApellido = "Monahan", SegundoApellido = "Murray", Ciudad = "Almería", Direccion = "C/ Veleta", Telefono = "662765413", FechaNacimiento = DateTime.Parse("1976-02-25"), IdSexoFk = 1, IdTipoPersonaFk = 2 },
            new Persona { Id = 19, Nif = "11578526G", Nombre = "Inma", PrimerApellido = "Lakin", SegundoApellido = "Yundt", Ciudad = "Almería", Direccion = "C/ Picos de Europa", Telefono = "678652431", FechaNacimiento = DateTime.Parse("1998-09-01"), IdSexoFk = 2, IdTipoPersonaFk = 1 },
            new Persona { Id = 20, Nif = "79221403L", Nombre = "Francesca", PrimerApellido = "Schowalter", SegundoApellido = "Muller", Ciudad = "Almería", Direccion = "C/ Quinto pino", Telefono = null, FechaNacimiento = DateTime.Parse("1980-10-31"), IdSexoFk = 1, IdTipoPersonaFk = 2 },
            new Persona { Id = 21, Nif = "79089577Y", Nombre = "Juan", PrimerApellido = "Gutiérrez", SegundoApellido = "López", Ciudad = "Almería", Direccion = "C/ Los pinos", Telefono = "678652431", FechaNacimiento = DateTime.Parse("1998-01-01"), IdSexoFk = 1, IdTipoPersonaFk = 1 },
            new Persona { Id = 22, Nif = "41491230N", Nombre = "Antonio", PrimerApellido = "Domínguez", SegundoApellido = "Guerrero", Ciudad = "Almería", Direccion = "C/ Cabo de Gata", Telefono = "626652498", FechaNacimiento = DateTime.Parse("1999-02-11"), IdSexoFk = 1, IdTipoPersonaFk = 1 },
            new Persona { Id = 23, Nif = "64753215G", Nombre = "Irene", PrimerApellido = "Hernández", SegundoApellido = "Martínez", Ciudad = "Almería", Direccion = "C/ Zapillo", Telefono = "628452384", FechaNacimiento = DateTime.Parse("1996-03-12"), IdSexoFk = 2, IdTipoPersonaFk = 1 },
            new Persona { Id = 24, Nif = "85135690V", Nombre = "Sonia", PrimerApellido = "Gea", SegundoApellido = "Ruiz", Ciudad = "Almería", Direccion = "C/ Mercurio", Telefono = "678812017", FechaNacimiento = DateTime.Parse("1995-04-13"), IdSexoFk = 2, IdTipoPersonaFk = 1 } 
        );
    }
}