using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces;

public interface IGrado : IGenericRepository<Grado>
{
    Task<IActionResult> asignaturasXGrados();
    Task<IActionResult> AsignaturasXGrados40();
}