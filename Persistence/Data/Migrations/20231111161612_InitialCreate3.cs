using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cursoEscolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AnoInicio = table.Column<int>(type: "int", nullable: false),
                    AnoFin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursoEscolar", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sexo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoAsignatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoAsignatura", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPersona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nif = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrimerApellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SegundoApellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    IdSexoFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoPersonaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_sexo_IdSexoFk",
                        column: x => x.IdSexoFk,
                        principalTable: "sexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_tipoPersona_IdTipoPersonaFk",
                        column: x => x.IdTipoPersonaFk,
                        principalTable: "tipoPersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "profesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdDepartamentoFk = table.Column<int>(type: "int", nullable: false),
                    IdPersonaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profesor_departamento_IdDepartamentoFk",
                        column: x => x.IdDepartamentoFk,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profesor_persona_IdPersonaFk",
                        column: x => x.IdPersonaFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asignatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creditos = table.Column<float>(type: "float", nullable: false),
                    IdTipoAsignaturaFk = table.Column<int>(type: "int", nullable: false),
                    Curso = table.Column<int>(type: "int", nullable: false),
                    Cuatrimestre = table.Column<int>(type: "int", nullable: false),
                    IdProfesorFk = table.Column<int>(type: "int", nullable: true),
                    IdGradoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_asignatura_grado_IdGradoFk",
                        column: x => x.IdGradoFk,
                        principalTable: "grado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_asignatura_profesor_IdProfesorFk",
                        column: x => x.IdProfesorFk,
                        principalTable: "profesor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_asignatura_tipoAsignatura_IdTipoAsignaturaFk",
                        column: x => x.IdTipoAsignaturaFk,
                        principalTable: "tipoAsignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "alumnoMatriculaAsignatura",
                columns: table => new
                {
                    IdAlumnoFk = table.Column<int>(type: "int", nullable: false),
                    IdAsignaturaFk = table.Column<int>(type: "int", nullable: false),
                    IdCursoEscolarFk = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnoMatriculaAsignatura", x => new { x.IdCursoEscolarFk, x.IdAlumnoFk, x.IdAsignaturaFk });
                    table.ForeignKey(
                        name: "FK_alumnoMatriculaAsignatura_asignatura_IdAsignaturaFk",
                        column: x => x.IdAsignaturaFk,
                        principalTable: "asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alumnoMatriculaAsignatura_cursoEscolar_IdCursoEscolarFk",
                        column: x => x.IdCursoEscolarFk,
                        principalTable: "cursoEscolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alumnoMatriculaAsignatura_persona_IdAlumnoFk",
                        column: x => x.IdAlumnoFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "cursoEscolar",
                columns: new[] { "Id", "AnoFin", "AnoInicio" },
                values: new object[,]
                {
                    { 1, 2014, 2015 },
                    { 2, 2015, 2016 },
                    { 3, 2016, 2017 },
                    { 4, 2017, 2018 },
                    { 5, 2018, 2019 }
                });

            migrationBuilder.InsertData(
                table: "departamento",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Informatica" },
                    { 2, "Matematicas" },
                    { 3, "Economia y Empresa" },
                    { 4, "Educacion" },
                    { 5, "Agronomia" },
                    { 6, "Quimica y Fisica" },
                    { 7, "Filologia" },
                    { 8, "Derecho" },
                    { 9, "Biologia y Geologia" }
                });

            migrationBuilder.InsertData(
                table: "grado",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Grado en Ingeniería Agrícola (Plan 2015)" },
                    { 2, "Grado en Ingeniería Eléctrica (Plan 2014)" },
                    { 3, "Grado en Ingeniería Electrónica Industrial (Plan 2010)" },
                    { 4, "Grado en Ingeniería Informática (Plan 2015)" },
                    { 5, "Grado en Ingeniería Mecánica (Plan 2010)" },
                    { 6, "Grado en Ingeniería Química Industrial (Plan 2010)" },
                    { 7, "Grado en Biotecnología (Plan 2015)" },
                    { 8, "Grado en Ciencias Ambientales (Plan 2009)" },
                    { 9, "Grado en Matemáticas (Plan 2010)" },
                    { 10, "Grado en Química (Plan 2009)" }
                });

            migrationBuilder.InsertData(
                table: "sexo",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "H" },
                    { 2, "M" }
                });

            migrationBuilder.InsertData(
                table: "tipoAsignatura",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Basica" },
                    { 2, "Obligatoria" },
                    { 3, "Optativa" }
                });

            migrationBuilder.InsertData(
                table: "tipoPersona",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Alumno" },
                    { 2, "Profesor" }
                });

            migrationBuilder.InsertData(
                table: "asignatura",
                columns: new[] { "Id", "Creditos", "Cuatrimestre", "Curso", "IdGradoFk", "IdProfesorFk", "IdTipoAsignaturaFk", "Nombre" },
                values: new object[,]
                {
                    { 22, 6f, 1, 3, 4, null, 3, "Ingenieria de Requisitos" },
                    { 23, 6f, 1, 3, 4, null, 3, "Integracion de las Tecnologías de la Informacion en las Organizaciones" },
                    { 24, 6f, 1, 3, 4, null, 3, "Modelado y Diseño del Software 1" },
                    { 25, 6f, 1, 3, 4, null, 3, "Multiprocesadores" },
                    { 26, 6f, 1, 3, 4, null, 3, "Seguridad y cumplimiento normativo" },
                    { 27, 6f, 1, 3, 4, null, 3, "Sistema de Información para las Organizaciones" },
                    { 28, 6f, 1, 3, 4, null, 3, "Tecnologias web" },
                    { 29, 6f, 1, 3, 4, null, 3, "Teoria de codigos y criptografia" },
                    { 30, 6f, 2, 3, 4, null, 3, "Administracion de bases de datos" },
                    { 31, 6f, 2, 3, 4, null, 3, "Herramientas y Metodos de Ingeniería del Software" },
                    { 32, 6f, 2, 3, 4, null, 3, "Informatica industrial y robotica" },
                    { 33, 6f, 2, 3, 4, null, 3, "Ingenieria de Sistemas de Informacion" },
                    { 34, 6f, 2, 3, 4, null, 3, "Modelado y Diseño del Software 2" },
                    { 35, 6f, 2, 3, 4, null, 3, "Negocio Electronico" },
                    { 36, 6f, 2, 3, 4, null, 3, "Perifericos e interfaces" },
                    { 37, 6f, 2, 3, 4, null, 3, "Sistemas de tiempo real" },
                    { 38, 6f, 2, 3, 4, null, 3, "Tecnologias de acceso a red" },
                    { 39, 6f, 2, 3, 4, null, 3, "Tratamiento digital de imagenes" },
                    { 40, 6f, 1, 4, 4, null, 3, "Administracion de redes y sistemas operativos" },
                    { 41, 6f, 1, 4, 4, null, 3, "Almacenes de Datos" },
                    { 42, 6f, 1, 4, 4, null, 3, "Fiabilidad y Gestión de Riesgos" },
                    { 43, 6f, 1, 4, 4, null, 3, "Lineas de Productos Software" },
                    { 44, 6f, 1, 4, 4, null, 3, "Procesos de Ingenieria del Software 1" },
                    { 45, 6f, 1, 4, 4, null, 3, "Tecnologias multimedia" },
                    { 46, 6f, 2, 4, 4, null, 3, "Analisis y planificación de las TI" },
                    { 47, 6f, 2, 4, 4, null, 3, "Desarrollo Rapido de Aplicaciones" },
                    { 48, 6f, 2, 4, 4, null, 3, "Gestion de la Calidad y de la Innovacion Tecnologica" },
                    { 49, 6f, 2, 4, 4, null, 3, "Inteligencia del Negocio" },
                    { 50, 6f, 2, 4, 4, null, 3, "Procesos de Ingenieria del Software 2" },
                    { 51, 6f, 2, 4, 4, null, 3, "Seguridad Informatica" },
                    { 52, 6f, 1, 1, 7, null, 1, "Biologia celular" },
                    { 53, 6f, 1, 1, 7, null, 1, "Fisica" },
                    { 54, 6f, 1, 1, 7, null, 1, "Matematicas I" },
                    { 55, 6f, 1, 1, 7, null, 1, "Quimica general" },
                    { 56, 6f, 1, 1, 7, null, 1, "Quimica organica" },
                    { 57, 6f, 2, 1, 7, null, 1, "Biologia vegetal y animal" },
                    { 58, 6f, 2, 1, 7, null, 1, "Bioquimica" },
                    { 59, 6f, 2, 1, 7, null, 1, "Genetica" },
                    { 60, 6f, 2, 1, 7, null, 1, "Matematicas II" },
                    { 61, 6f, 2, 1, 7, null, 1, "Microbiologia" },
                    { 62, 6f, 1, 2, 7, null, 2, "Botanica agricola" },
                    { 63, 6f, 1, 2, 7, null, 2, "Fisiologia vegetal" },
                    { 64, 6f, 1, 2, 7, null, 2, "Genetica molecular" },
                    { 65, 6f, 1, 2, 7, null, 2, "Ingenieria bioquimica" },
                    { 66, 6f, 1, 2, 7, null, 2, "Termodinamica y cinetica quimica aplicada" },
                    { 67, 6f, 2, 2, 7, null, 2, "Biorreactores" },
                    { 68, 6f, 2, 2, 7, null, 2, "Biotecnologia microbiana" },
                    { 69, 6f, 2, 2, 7, null, 2, "Ingenieria genetica" },
                    { 70, 6f, 2, 2, 7, null, 2, "Inmunologia" },
                    { 71, 6f, 2, 2, 7, null, 2, "Virologia" },
                    { 72, 4.5f, 1, 3, 7, null, 3, "Bases moleculares del desarrollo vegetal" },
                    { 73, 4.5f, 1, 3, 7, null, 3, "Fisiologia animal" },
                    { 74, 6f, 1, 3, 7, null, 3, "Metabolismo y biosintesis de biomoleculas" },
                    { 75, 6f, 1, 3, 7, null, 3, "Operaciones de separacion" },
                    { 76, 4.5f, 1, 3, 7, null, 3, "Patologia molecular de plantas" },
                    { 78, 4.5f, 2, 3, 7, null, 3, "Bioinformatica" },
                    { 79, 4.5f, 2, 3, 7, null, 3, "Biotecnologia de los productos hortofruticulas" },
                    { 80, 6f, 2, 3, 7, null, 3, "Biotecnologia vegetal" },
                    { 81, 4.5f, 2, 3, 7, null, 3, "Genomica y proteomica" },
                    { 82, 6f, 2, 3, 7, null, 3, "Procesos biotecnologicos" },
                    { 83, 4.5f, 2, 3, 7, null, 3, "Técnicas instrumentales avanzadas" }
                });

            migrationBuilder.InsertData(
                table: "persona",
                columns: new[] { "Id", "Ciudad", "Direccion", "FechaNacimiento", "IdSexoFk", "IdTipoPersonaFk", "Nif", "Nombre", "PrimerApellido", "SegundoApellido", "Telefono" },
                values: new object[,]
                {
                    { 1, "Almeria", "C/ Real del barrio alto", new DateTime(1991, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "26902806M", "Salvador", "Sanchez", "Perez", "950254837" },
                    { 2, "Almería", "C/ Mercurio", new DateTime(1992, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "89542419S", "Juan", "Saez", "Vega", "618253876" },
                    { 3, "Almería", "C/ Marte", new DateTime(1979, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "11105554G", "Zoe", "Ramirez", "Gea", "618223876" },
                    { 4, "Almería", "C/ Estrella fugaz", new DateTime(2000, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "17105885A", "Pedro", "Heller", "Pagac", null },
                    { 5, "Almería", "C/ Venus", new DateTime(1978, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "38223286T", "David", "Schmidt", "Fisher", "678516294" },
                    { 6, "Almería", "C/ Júpiter", new DateTime(1998, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "04233869Y", "José", "Koss", "Bayer", "628349590" },
                    { 7, "Almería", "C/ Neptuno", new DateTime(1999, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "97258166K", "Ismael", "Strosin", "Turcotte", null },
                    { 8, "Almería", "C/ Saturno", new DateTime(1977, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "79503962T", "Cristina", "Lemke", "Rutherford", "669162534" },
                    { 9, "Almería", "C/ Urano", new DateTime(1996, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "82842571K", "Ramón", "Herzog", "Tremblay", "626351429" },
                    { 10, "Almería", "C/ Plutón", new DateTime(1977, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "61142000L", "Esther", "Spencer", "Lakin", null },
                    { 11, "Almería", "C/ Andarax", new DateTime(1997, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "46900725E", "Daniel", "Herman", "Pacocha", "679837625" },
                    { 12, "Almería", "C/ Almanzora", new DateTime(1971, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "85366986W", "Carmen", "Streich", "Hirthe", null },
                    { 13, "Almería", "C/ Guadalquivir", new DateTime(1980, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "73571384L", "Alfredo", "Stiedemann", "Morissette", "950896725" },
                    { 14, "Almería", "C/ Duero", new DateTime(1977, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "82937751G", "Manolo", "Hamill", "Kozey", "950263514" },
                    { 15, "Almería", "C/ Tajo", new DateTime(1980, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "80502866Z", "Alejandro", "Kohler", "Schoen", "668726354" },
                    { 16, "Almería", "C/ Sierra de los Filabres", new DateTime(1982, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "10485008K", "Antonio", "Fahey", "Considine", null },
                    { 17, "Almería", "C/ Sierra de Gádor", new DateTime(1973, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "85869555K", "Guillermo", "Ruecker", "Upton", null },
                    { 18, "Almería", "C/ Veleta", new DateTime(1976, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "04326833G", "Micaela", "Monahan", "Murray", "662765413" },
                    { 19, "Almería", "C/ Picos de Europa", new DateTime(1998, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "11578526G", "Inma", "Lakin", "Yundt", "678652431" },
                    { 20, "Almería", "C/ Quinto pino", new DateTime(1980, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "79221403L", "Francesca", "Schowalter", "Muller", null },
                    { 21, "Almería", "C/ Los pinos", new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "79089577Y", "Juan", "Gutiérrez", "López", "678652431" },
                    { 22, "Almería", "C/ Cabo de Gata", new DateTime(1999, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "41491230N", "Antonio", "Domínguez", "Guerrero", "626652498" },
                    { 23, "Almería", "C/ Zapillo", new DateTime(1996, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "64753215G", "Irene", "Hernández", "Martínez", "628452384" },
                    { 24, "Almería", "C/ Mercurio", new DateTime(1995, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "85135690V", "Sonia", "Gea", "Ruiz", "678812017" }
                });

            migrationBuilder.InsertData(
                table: "profesor",
                columns: new[] { "Id", "IdDepartamentoFk", "IdPersonaFk" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 2, 5 },
                    { 3, 3, 8 },
                    { 4, 4, 10 },
                    { 5, 4, 12 },
                    { 6, 6, 13 },
                    { 7, 1, 14 },
                    { 8, 2, 15 },
                    { 9, 3, 16 },
                    { 10, 4, 17 },
                    { 11, 5, 18 },
                    { 12, 6, 20 },
                    { 13, 2, 7 },
                    { 14, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "asignatura",
                columns: new[] { "Id", "Creditos", "Cuatrimestre", "Curso", "IdGradoFk", "IdProfesorFk", "IdTipoAsignaturaFk", "Nombre" },
                values: new object[,]
                {
                    { 1, 6f, 1, 1, 4, 3, 1, "Algegra lineal y matematica discreta" },
                    { 2, 6f, 1, 1, 4, 14, 1, "Calculo" },
                    { 3, 6f, 1, 1, 4, 3, 1, "Fisica para informatica" },
                    { 4, 6f, 1, 1, 4, 14, 1, "Introduccion a la programacion" },
                    { 5, 6f, 1, 1, 4, 3, 1, "Organizacion y gestion de empresas" },
                    { 6, 6f, 2, 1, 4, 14, 1, "Estadistica" },
                    { 7, 6f, 2, 1, 4, 3, 1, "Estructura y tecnologia de computadores" },
                    { 8, 6f, 2, 1, 4, 14, 1, "Fundamentos de electronica" },
                    { 9, 6f, 2, 1, 4, 3, 1, "Logica y algoritmica" },
                    { 10, 6f, 2, 1, 4, 14, 1, "Metodologia de la programacion" },
                    { 11, 6f, 1, 2, 4, 3, 1, "Arquitectura de Computadores" },
                    { 12, 6f, 1, 2, 4, 3, 2, "Estructura de Datos y Algoritmos I" },
                    { 13, 6f, 1, 2, 4, 14, 2, "Ingenieria del Software" },
                    { 14, 6f, 1, 2, 4, 3, 2, "Sistemas Inteligentes" },
                    { 15, 6f, 1, 2, 4, 14, 2, "Sistemas Operativos" },
                    { 16, 6f, 2, 2, 4, 14, 1, "Bases de Datos" },
                    { 17, 6f, 2, 2, 4, 14, 2, "Estructura de Datos y Algoritmos II" },
                    { 18, 6f, 2, 2, 4, 3, 2, "Fundamentos de Redes de Computadores" },
                    { 19, 6f, 2, 2, 4, 3, 2, "Planificaciin y Gestiin de Proyectos Informaticos" },
                    { 20, 6f, 1, 3, 4, 14, 2, "Programacion de Servicios Software" },
                    { 21, 6f, 1, 3, 4, 14, 2, "Desarrollo de interfaces de usuario" }
                });

            migrationBuilder.InsertData(
                table: "alumnoMatriculaAsignatura",
                columns: new[] { "IdAlumnoFk", "IdAsignaturaFk", "IdCursoEscolarFk", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 1, 2, 1, 2 },
                    { 1, 3, 1, 3 },
                    { 2, 1, 1, 4 },
                    { 2, 2, 1, 5 },
                    { 2, 3, 1, 6 },
                    { 4, 1, 1, 7 },
                    { 4, 2, 1, 8 },
                    { 4, 3, 1, 9 },
                    { 19, 1, 5, 30 },
                    { 19, 2, 5, 31 },
                    { 19, 3, 5, 32 },
                    { 19, 4, 5, 33 },
                    { 19, 5, 5, 34 },
                    { 19, 6, 5, 35 },
                    { 19, 7, 5, 36 },
                    { 19, 8, 5, 37 },
                    { 19, 9, 5, 38 },
                    { 19, 10, 5, 39 },
                    { 23, 1, 5, 20 },
                    { 23, 2, 5, 21 },
                    { 23, 3, 5, 22 },
                    { 23, 4, 5, 23 },
                    { 23, 5, 5, 24 },
                    { 23, 6, 5, 25 },
                    { 23, 7, 5, 26 },
                    { 23, 8, 5, 27 },
                    { 23, 9, 5, 28 },
                    { 23, 10, 5, 29 },
                    { 24, 1, 5, 10 },
                    { 24, 2, 5, 11 },
                    { 24, 3, 5, 12 },
                    { 24, 4, 5, 13 },
                    { 24, 5, 5, 14 },
                    { 24, 6, 5, 15 },
                    { 24, 7, 5, 16 },
                    { 24, 8, 5, 17 },
                    { 24, 9, 5, 18 },
                    { 24, 10, 5, 19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_alumnoMatriculaAsignatura_IdAlumnoFk",
                table: "alumnoMatriculaAsignatura",
                column: "IdAlumnoFk");

            migrationBuilder.CreateIndex(
                name: "IX_alumnoMatriculaAsignatura_IdAsignaturaFk",
                table: "alumnoMatriculaAsignatura",
                column: "IdAsignaturaFk");

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_IdGradoFk",
                table: "asignatura",
                column: "IdGradoFk");

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_IdProfesorFk",
                table: "asignatura",
                column: "IdProfesorFk");

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_IdTipoAsignaturaFk",
                table: "asignatura",
                column: "IdTipoAsignaturaFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdSexoFk",
                table: "persona",
                column: "IdSexoFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdTipoPersonaFk",
                table: "persona",
                column: "IdTipoPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_profesor_IdDepartamentoFk",
                table: "profesor",
                column: "IdDepartamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_profesor_IdPersonaFk",
                table: "profesor",
                column: "IdPersonaFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alumnoMatriculaAsignatura");

            migrationBuilder.DropTable(
                name: "asignatura");

            migrationBuilder.DropTable(
                name: "cursoEscolar");

            migrationBuilder.DropTable(
                name: "grado");

            migrationBuilder.DropTable(
                name: "profesor");

            migrationBuilder.DropTable(
                name: "tipoAsignatura");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "sexo");

            migrationBuilder.DropTable(
                name: "tipoPersona");
        }
    }
}
