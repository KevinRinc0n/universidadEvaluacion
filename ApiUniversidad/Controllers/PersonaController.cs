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

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}