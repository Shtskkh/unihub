using Core.Application.Shared;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Faculties.Create;

public sealed record CreateFacultyCommand(string Title) : IRequest<Result<int, Error>>;