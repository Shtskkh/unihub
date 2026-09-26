using Core.Api.Contracts.Faculties;
using Core.Application.Faculties.Create;
using Core.Application.Faculties.GetAll;
using Core.Application.Faculties.GetById;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public sealed class FacultiesController(IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<FacultyDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync([FromServices] GetAllFacultiesHandler handler, CancellationToken ct)
    {
        var command = new GetAllFacultiesRequest();
        var commandResult = await handler.Handle(command, ct);

        var facultiesDto = mapper.Map<IReadOnlyCollection<FacultyDto>>(commandResult);

        return Ok(facultiesDto);
    }

    [HttpGet("{facultyId:int}")]
    [ProducesResponseType(typeof(FacultyDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(
        [FromServices] GetFacultyByIdHandler handler,
        int facultyId,
        CancellationToken ct
    )
    {
        var command = new GetFacultyByIdCommand(facultyId);
        var commandResult = await handler.Handle(command, ct);

        if (commandResult.IsFailure(out var error))
            return NotFound(error);

        commandResult.IsSuccess(out var faculty);

        return Ok(mapper.Map<FacultyDto>(faculty!));
    }

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