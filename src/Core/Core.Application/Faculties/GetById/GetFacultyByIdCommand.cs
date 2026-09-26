using Core.Application.Shared;
using Core.Domain.Faculties;
using LightResults;

namespace Core.Application.Faculties.GetById;

public sealed record GetFacultyByIdCommand(int FacultyId) : IRequest<Result<Faculty>>;