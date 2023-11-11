using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUniversidad.Controllers;

public class TipoAsignaturaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TipoAsignaturaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoAsignatura>>> Get()
    {
        var tipoAsignatura = await unitofwork.TipoAsignaturas.GetAllAsync();
        return mapper.Map<List<TipoAsignatura>>(tipoAsignatura);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoAsignatura>> Get(int id)
    {
        var tipoAsignatura = await unitofwork.TipoAsignaturas.GetByIdAsync(id);
        return mapper.Map<TipoAsignatura>(tipoAsignatura);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoAsignatura>> Post(TipoAsignatura tipoAsignaturaDto)
    {
        var tipoAsignatura = this.mapper.Map<TipoAsignatura>(tipoAsignaturaDto);
        this.unitofwork.TipoAsignaturas.Add(tipoAsignatura);
        await unitofwork.SaveAsync();
        if (tipoAsignatura == null){
            return BadRequest();
        }
        tipoAsignaturaDto.Id = tipoAsignatura.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoAsignaturaDto.Id }, tipoAsignaturaDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoAsignatura>> Put (int id, [FromBody]TipoAsignatura tipoAsignaturaDto)
    {
        if(tipoAsignaturaDto == null)
            return NotFound();

        var tipoAsignatura = this.mapper.Map<TipoAsignatura>(tipoAsignaturaDto);
        unitofwork.TipoAsignaturas.Update(tipoAsignatura);
        await unitofwork.SaveAsync();
        return tipoAsignaturaDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var tipoAsignatura = await unitofwork.TipoAsignaturas.GetByIdAsync(id);

        if (tipoAsignatura == null)
        {
            return Notfound();
        }

        unitofwork.TipoAsignaturas.Remove(tipoAsignatura);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}