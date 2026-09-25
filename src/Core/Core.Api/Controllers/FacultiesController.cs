using Core.Api.Contracts.Faculties;
using Core.Application.Faculties.Create;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public sealed class FacultiesController(IMapper mapper) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created, Description = "ID факультета.")]
    public async Task<IActionResult> CreateFacultyAsync(
        [FromServices] CreateFacultyHandler handler,
        [FromForm] CreateFacultyDto dto,
        CancellationToken ct)
    {
        var command = mapper.Map<CreateFacultyCommand>(dto);
        var commandResult = await handler.Handle(command, ct);

        if (commandResult.IsFailure(out var error))
            return BadRequest(error);

        commandResult.IsSuccess(out var id);
        return Created($"/api/v1/faculties/{id}", id);
    }
}