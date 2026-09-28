using Core.Application.Shared;
using Core.Domain.Departments;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Faculties.GetDepartments;

public sealed record GetFacultyDepartmentsRequest(int FacultyId)
    : IRequest<Result<IReadOnlyCollection<Department>, Error>>;