using Core.Application.Shared;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Departments.Create;

public sealed record CreateDepartmentCommand(string Title, int FacultyId) : IRequest<Result<int, Error>>;