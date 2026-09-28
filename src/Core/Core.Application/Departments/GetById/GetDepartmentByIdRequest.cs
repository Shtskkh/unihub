using Core.Application.Shared;
using Core.Domain.Departments;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Departments.GetById;

public sealed record GetDepartmentByIdRequest(int DepartmentId) : IRequest<Result<Department, Error>>;