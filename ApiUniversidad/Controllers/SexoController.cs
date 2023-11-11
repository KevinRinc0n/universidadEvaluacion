using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUniversidad.Controllers;

public class SexoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public SexoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Sexo>>> Get()
    {
        var sexo = await unitofwork.Sexos.GetAllAsync();
        return mapper.Map<List<Sexo>>(sexo);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Sexo>> Get(int id)
    {
        var sexo = await unitofwork.Sexos.GetByIdAsync(id);
        return mapper.Map<Sexo>(sexo);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Sexo>> Post(Sexo sexoDto)
    {
        var sexo = this.mapper.Map<Sexo>(sexoDto);
        this.unitofwork.Sexos.Add(sexo);
        await unitofwork.SaveAsync();
        if (sexo == null){
            return BadRequest();
        }
        sexoDto.Id = sexo.Id;
        return CreatedAtAction(nameof(Post), new { id = sexoDto.Id }, sexoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Sexo>> Put (int id, [FromBody]Sexo sexoDto)
    {
        if(sexoDto == null)
            return NotFound();

        var sexo = this.mapper.Map<Sexo>(sexoDto);
        unitofwork.Sexos.Update(sexo);
        await unitofwork.SaveAsync();
        return sexoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var sexo = await unitofwork.Sexos.GetByIdAsync(id);

        if (sexo == null)
        {
            return Notfound();
        }

        unitofwork.Sexos.Remove(sexo);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}