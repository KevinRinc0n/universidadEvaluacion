using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUniversidad.Controllers;

public class TipoPersonaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoPersona>>> Get()
    {
        var tipoPersona = await unitofwork.TipoPersonas.GetAllAsync();
        return mapper.Map<List<TipoPersona>>(tipoPersona);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoPersona>> Get(int id)
    {
        var tipoPersona = await unitofwork.TipoPersonas.GetByIdAsync(id);
        return mapper.Map<TipoPersona>(tipoPersona);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoPersona>> Post(TipoPersona tipoPersonaDto)
    {
        var tipoPersona = this.mapper.Map<TipoPersona>(tipoPersonaDto);
        this.unitofwork.TipoPersonas.Add(tipoPersona);
        await unitofwork.SaveAsync();
        if (tipoPersona == null){
            return BadRequest();
        }
        tipoPersonaDto.Id = tipoPersona.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoPersonaDto.Id }, tipoPersonaDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoPersona>> Put (int id, [FromBody]TipoPersona tipoPersonaDto)
    {
        if(tipoPersonaDto == null)
            return NotFound();

        var tipoPersona = this.mapper.Map<TipoPersona>(tipoPersonaDto);
        unitofwork.TipoPersonas.Update(tipoPersona);
        await unitofwork.SaveAsync();
        return tipoPersonaDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var tipoPersona = await unitofwork.TipoPersonas.GetByIdAsync(id);

        if (tipoPersona == null)
        {
            return Notfound();
        }

        unitofwork.TipoPersonas.Remove(tipoPersona);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}