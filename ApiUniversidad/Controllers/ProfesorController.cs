using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUniversidad.Controllers;

public class ProfesorController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ProfesorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Profesor>>> Get()
    {
        var profesor = await unitofwork.Profesores.GetAllAsync();
        return mapper.Map<List<Profesor>>(profesor);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Profesor>> Get(int id)
    {
        var profesor = await unitofwork.Profesores.GetByIdAsync(id);
        return mapper.Map<Profesor>(profesor);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Profesor>> Post(Profesor profesorDto)
    {
        var profesor = this.mapper.Map<Profesor>(profesorDto);
        this.unitofwork.Profesores.Add(profesor);
        await unitofwork.SaveAsync();
        if (profesor == null){
            return BadRequest();
        }
        profesorDto.Id = profesor.Id;
        return CreatedAtAction(nameof(Post), new { id = profesorDto.Id }, profesorDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Profesor>> Put (int id, [FromBody]Profesor profesorDto)
    {
        if(profesorDto == null)
            return NotFound();

        var profesor = this.mapper.Map<Profesor>(profesorDto);
        unitofwork.Profesores.Update(profesor);
        await unitofwork.SaveAsync();
        return profesorDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var profesor = await unitofwork.Profesores.GetByIdAsync(id);

        if (profesor == null)
        {
            return Notfound();
        }

        unitofwork.Profesores.Remove(profesor);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}