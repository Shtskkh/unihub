using Core.Api.Contracts.Departments;
using Core.Api.Shared;
using Core.Application.Departments.Create;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public sealed class DepartmentsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    public async Task<IResult> CreateDepartmentAsync(
        [FromServices] CreateDepartmentHandler handler,
        [FromForm] CreateDepartmentDto dto,
        CancellationToken cancellationToken)
    {
        var command = dto.Adapt<CreateDepartmentCommand>();
        var commandResult = await handler.Handle(command, cancellationToken);

        return commandResult.ToHttpResult(id => Results.Created($"/api/v1/departments/{id}", id));
    }
}