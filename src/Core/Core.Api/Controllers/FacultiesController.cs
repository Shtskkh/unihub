using Core.Api.Contracts.Faculties;
using Core.Api.Shared;
using Core.Application.Faculties.Create;
using Core.Application.Faculties.GetAll;
using Core.Application.Faculties.GetById;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public sealed class FacultiesController(IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<FacultyDto>), StatusCodes.Status200OK)]
    public async Task<IResult> GetAllAsync([FromServices] GetAllFacultiesHandler handler, CancellationToken ct)
    {
        var command = new GetAllFacultiesRequest();
        var commandResult = await handler.Handle(command, ct);

        return Results.Ok(commandResult.Adapt<IReadOnlyCollection<FacultyDto>>());
    }

    [HttpGet("{facultyId:int}")]
    [ProducesResponseType(typeof(FacultyDto), StatusCodes.Status200OK)]
    public async Task<IResult> GetByIdAsync(
        [FromServices] GetFacultyByIdHandler handler,
        int facultyId,
        CancellationToken ct
    )
    {
        var command = new GetFacultyByIdCommand(facultyId);
        var commandResult = await handler.Handle(command, ct);

        return commandResult.ToHttpResult(source => Results.Ok(source.Adapt<FacultyDto>()));
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created, Description = "ID факультета.")]
    public async Task<IResult> CreateFacultyAsync(
        [FromServices] CreateFacultyHandler handler,
        [FromForm] CreateFacultyDto dto,
        CancellationToken ct)
    {
        var command = mapper.Map<CreateFacultyCommand>(dto);
        var commandResult = await handler.Handle(command, ct);

        return commandResult.ToHttpResult(id => Results.Created($"/api/v1/faculties/{id}", id));
    }
}