using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUniversidad.Controllers;

public class CursoEscolarController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CursoEscolarController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CursoEscolar>>> Get()
    {
        var cursoEscolar = await unitofwork.CursoEscolares.GetAllAsync();
        return mapper.Map<List<CursoEscolar>>(cursoEscolar);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CursoEscolar>> Get(int id)
    {
        var cursoEscolar = await unitofwork.CursoEscolares.GetByIdAsync(id);
        return mapper.Map<CursoEscolar>(cursoEscolar);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CursoEscolar>> Post(CursoEscolar cursoEscolarDto)
    {
        var cursoEscolar = this.mapper.Map<CursoEscolar>(cursoEscolarDto);
        this.unitofwork.CursoEscolares.Add(cursoEscolar);
        await unitofwork.SaveAsync();
        if (cursoEscolar == null){
            return BadRequest();
        }
        cursoEscolarDto.Id = cursoEscolar.Id;
        return CreatedAtAction(nameof(Post), new { id = cursoEscolarDto.Id }, cursoEscolarDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CursoEscolar>> Put (int id, [FromBody]CursoEscolar CursoEscolarDto)
    {
        if(CursoEscolarDto == null)
            return NotFound();

        var CursoEscolar = this.mapper.Map<CursoEscolar>(CursoEscolarDto);
        unitofwork.CursoEscolares.Update(CursoEscolar);
        await unitofwork.SaveAsync();
        return CursoEscolarDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var CursoEscolar = await unitofwork.CursoEscolares.GetByIdAsync(id);

        if (CursoEscolar == null)
        {
            return Notfound();
        }

        unitofwork.CursoEscolares.Remove(CursoEscolar);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}