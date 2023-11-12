using ApiUniversidad.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiUniversidad.Controllers;

public class AsignaturaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public AsignaturaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Asignatura>>> Get()
    {
        var asignatura = await unitofwork.Asignaturas.GetAllAsync();
        return mapper.Map<List<Asignatura>>(asignatura);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Asignatura>> Get(int id)
    {
        var asignatura = await unitofwork.Asignaturas.GetByIdAsync(id);
        return mapper.Map<Asignatura>(asignatura);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Asignatura>> Post(Asignatura asignaturaDto)
    {
        var asignatura = this.mapper.Map<Asignatura>(asignaturaDto);
        this.unitofwork.Asignaturas.Add(asignatura);
        await unitofwork.SaveAsync();
        if (asignatura == null){
            return BadRequest();
        }
        asignaturaDto.Id = asignatura.Id;
        return CreatedAtAction(nameof(Post), new { id = asignaturaDto.Id }, asignaturaDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Asignatura>> Put (int id, [FromBody]Asignatura asignaturaDto)
    {
        if(asignaturaDto == null)
            return NotFound();

        var asignatura = this.mapper.Map<Asignatura>(asignaturaDto);
        unitofwork.Asignaturas.Update(asignatura);
        await unitofwork.SaveAsync();
        return asignaturaDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var asignatura = await unitofwork.Asignaturas.GetByIdAsync(id);

        if (asignatura == null)
        {
            return Notfound();
        }

        unitofwork.Asignaturas.Remove(asignatura);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("asignaturaInformatica")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AsignaturaDto>>> GetAsignaturas()
    {
        var asignaturaInformaticas = await unitofwork.Asignaturas.AsignaturasInformatica();
        return mapper.Map<List<AsignaturaDto>>(asignaturaInformaticas);
    }

    [HttpGet("alumno2M")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AsignaturaMDto>>> GetAlumnoM()
    {
        var alumno = await unitofwork.Asignaturas.AsignaturasAlumnoM();
        return mapper.Map<List<AsignaturaMDto>>(alumno);
    }

    [HttpGet("profesorSinAsignatura")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AsignaturaProfeDto>>> GetProfeSin()
    {
        var profesorSinAsign = await unitofwork.Asignaturas.ProfesoresSinAsignatura();
        return mapper.Map<List<AsignaturaProfeDto>>(profesorSinAsign);
    }

    [HttpGet("matriculadosXCurso")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> GetmatriculadosXCurso()
    {
        var alumnosMatriculadosXCurso = await unitofwork.AlumnoMatriculaAsignaturas.AlumnosMatriculados();
        return Ok(alumnosMatriculadosXCurso);
    }

    [HttpGet("asignaturaNoProfe")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AsignaturaSinDto>>> GetAsignaturaSinProfe()
    {
        var asignaturaSinProf = await unitofwork.Asignaturas.AsignaturaSinProfe();
        return mapper.Map<List<AsignaturaSinDto>>(asignaturaSinProf);
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}