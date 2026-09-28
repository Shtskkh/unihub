using Core.Application.Shared;
using Core.Contracts.Departments;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Faculties.GetDepartments;

public sealed record GetFacultyDepartmentsRequest(int FacultyId)
    : IRequest<Result<IReadOnlyCollection<DepartmentDto>, Error>>;