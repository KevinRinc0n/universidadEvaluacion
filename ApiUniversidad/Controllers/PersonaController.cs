using ApiUniversidad.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUniversidad.Controllers;

public class PersonaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Persona>>> Get()
    {
        var persona = await unitofwork.Personas.GetAllAsync();
        return mapper.Map<List<Persona>>(persona);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Persona>> Get(int id)
    {
        var persona = await unitofwork.Personas.GetByIdAsync(id);
        return mapper.Map<Persona>(persona);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persona>> Post(Persona personaDto)
    {
        var persona = this.mapper.Map<Persona>(personaDto);
        this.unitofwork.Personas.Add(persona);
        await unitofwork.SaveAsync();
        if (persona == null){
            return BadRequest();
        }
        personaDto.Id = persona.Id;
        return CreatedAtAction(nameof(Post), new { id = personaDto.Id }, personaDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Persona>> Put (int id, [FromBody]Persona personaDto)
    {
        if(personaDto == null)
            return NotFound();

        var grado = this.mapper.Map<Persona>(personaDto);
        unitofwork.Personas.Update(grado);
        await unitofwork.SaveAsync();
        return personaDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var persona = await unitofwork.Personas.GetByIdAsync(id);

        if (persona == null)
        {
            return Notfound();
        }

        unitofwork.Personas.Remove(persona);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("menorAMayor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> GetPersonasAlum()
    {
        var alumnosMenorMayor = await unitofwork.Personas.AlumnosMenorMayor();
        return mapper.Map<List<PersonaDto>>(alumnosMenorMayor);
    }

    [HttpGet("alumnosSinNumero")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> GetSinNumero()
    {
        var sinNumero = await unitofwork.Personas.AlumnosSinNumero();
        return mapper.Map<List<PersonaDto>>(sinNumero);
    }

    [HttpGet("alumnos1999")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaFechaDto>>> GetNacidos1999()
    {
        var alumnos1999 = await unitofwork.Personas.Alumnos1999();
        return mapper.Map<List<PersonaFechaDto>>(alumnos1999);
    }

    [HttpGet("alumnasInformatica")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaAlumnaDto>>> GetAlumnas()
    {
        var alumnasInformaticas = await unitofwork.Personas.AlumnasInformatica();
        return mapper.Map<List<PersonaAlumnaDto>>(alumnasInformaticas);
    }

    [HttpGet("alumnoMatriculado201819")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaAlumnaDto>>> GetAlumnoMatricu()
    {
        var matriculados201819 = await unitofwork.Personas.AlumnosMatriculados();
        return mapper.Map<List<PersonaAlumnaDto>>(matriculados201819);
    }

    [HttpGet("totalAlumnas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> GetAlumnasTotal()
    {
        var totalAlumnas = await unitofwork.Personas.TotalAlumnas();
        return Ok(totalAlumnas);
    }

    [HttpGet("total1999")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> GetAlumnos1999()
    {
        var totalAlumnos = await unitofwork.Personas.AlumnosNacieron1999();
        return Ok(totalAlumnos);
    }

    [HttpGet("alumnoMasJoven")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersoAlumMasJovenDto>> GetMasJoven()
    {
        var masJoven = await unitofwork.Personas.AlumnoMasJoven();
        return mapper.Map<PersoAlumMasJovenDto>(masJoven);
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}