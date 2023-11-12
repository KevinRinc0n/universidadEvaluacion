using ApiUniversidad.Dtos;
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

    [HttpGet("profesoresSinNumero")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaProfDto>>> GetSinNumero()
    {
        var sinNumero = await unitofwork.Personas.ProfesoresSinNumero();
        return mapper.Map<List<PersonaProfDto>>(sinNumero);
    }

    [HttpGet("profesorDepartamento")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfesorDepartamentoDto>>> GetProfDep()
    {
        var profesorDepa = await unitofwork.Personas.ProfesorDepartamento();
        return mapper.Map<List<ProfesorDepartamentoDto>>(profesorDepa);
    }

    [HttpGet("departamentoProfesor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfesorDeptoDto>>> GetDepartamentoProf()
    {
        var departamentoProfe = await unitofwork.Profesores.DepartamentoProfesores();
        return mapper.Map<List<ProfesorDeptoDto>>(departamentoProfe);
    }

    [HttpGet("profesorSinDep")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfesorDeptoDto>>> GetProfSinDep()
    {
        var profeSinDepartamento = await unitofwork.Profesores.ProfesoresSinDepartamento();
        return mapper.Map<List<ProfesorDeptoDto>>(profeSinDepartamento);
    }

    [HttpGet("profeSinAsing")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfeSinAsingDto>>> GetProfeSin()
    {
        var profesorSinAsign = await unitofwork.Profesores.ProfesoresSinAsignatura();
        return mapper.Map<List<ProfeSinAsingDto>>(profesorSinAsign);
    }

    [HttpGet("asignatuXProfe")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<object>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> GetAsigXProfe()
    {
        var asignaturasXProfesor = await unitofwork.Profesores.AsignaturasXProfesor();
        return Ok(asignaturasXProfesor);
    }

    [HttpGet("profesorSinDepartament")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfesorDeptoDto>>> GetProfNoDep()
    {
        var profeSinDepartamento = await unitofwork.Profesores.ProfesoresSinDep();
        return mapper.Map<List<ProfesorDeptoDto>>(profeSinDepartamento);
    }

    [HttpGet("profesorDepSinAsignatura")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfesorDeptoDto>>> GetProDepNoAsign()
    {
        var profeSinAsignatura = await unitofwork.Profesores.ProfesoresDepSinAsignatura();
        return mapper.Map<List<ProfesorDeptoDto>>(profeSinAsignatura);
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}