using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUniversidad.Controllers;

public class DepartamentoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Departamento>>> Get()
    {
        var departamento = await unitofwork.Departamentos.GetAllAsync();
        return mapper.Map<List<Departamento>>(departamento);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Departamento>> Get(int id)
    {
        var departamento = await unitofwork.Departamentos.GetByIdAsync(id);
        return mapper.Map<Departamento>(departamento);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Departamento>> Post(Departamento departamentoDto)
    {
        var Departamento = this.mapper.Map<Departamento>(departamentoDto);
        this.unitofwork.Departamentos.Add(Departamento);
        await unitofwork.SaveAsync();
        if (Departamento == null){
            return BadRequest();
        }
        departamentoDto.Id = Departamento.Id;
        return CreatedAtAction(nameof(Post), new { id = departamentoDto.Id }, departamentoDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Departamento>> Put (int id, [FromBody]Departamento departamentoDto)
    {
        if(departamentoDto == null)
            return NotFound();

        var departamento = this.mapper.Map<Departamento>(departamentoDto);
        unitofwork.Departamentos.Update(departamento);
        await unitofwork.SaveAsync();
        return departamentoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var departamento = await unitofwork.Departamentos.GetByIdAsync(id);

        if (departamento == null)
        {
            return Notfound();
        }

        unitofwork.Departamentos.Remove(departamento);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}