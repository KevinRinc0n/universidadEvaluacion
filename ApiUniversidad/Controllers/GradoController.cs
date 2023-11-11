using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUniversidad.Controllers;

public class GradoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public GradoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Grado>>> Get()
    {
        var grado = await unitofwork.Grados.GetAllAsync();
        return mapper.Map<List<Grado>>(grado);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Grado>> Get(int id)
    {
        var grado = await unitofwork.Grados.GetByIdAsync(id);
        return mapper.Map<Grado>(grado);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Grado>> Post(Grado gradoDto)
    {
        var Grado = this.mapper.Map<Grado>(gradoDto);
        this.unitofwork.Grados.Add(Grado);
        await unitofwork.SaveAsync();
        if (Grado == null){
            return BadRequest();
        }
        gradoDto.Id = Grado.Id;
        return CreatedAtAction(nameof(Post), new { id = gradoDto.Id }, gradoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Grado>> Put (int id, [FromBody]Grado gradoDto)
    {
        if(gradoDto == null)
            return NotFound();

        var grado = this.mapper.Map<Grado>(gradoDto);
        unitofwork.Grados.Update(grado);
        await unitofwork.SaveAsync();
        return gradoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var grado = await unitofwork.Grados.GetByIdAsync(id);

        if (grado == null)
        {
            return Notfound();
        }

        unitofwork.Grados.Remove(grado);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}