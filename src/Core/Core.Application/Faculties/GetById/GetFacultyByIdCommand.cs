using Core.Application.Shared;
using Core.Domain.Faculties;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Faculties.GetById;

public sealed record GetFacultyByIdCommand(int FacultyId) : IRequest<Result<Faculty, Error>>;