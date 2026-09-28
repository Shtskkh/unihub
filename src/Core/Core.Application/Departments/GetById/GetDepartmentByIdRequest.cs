using Core.Application.Shared;
using Core.Contracts.Departments;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Departments.GetById;

public sealed record GetDepartmentByIdRequest(int DepartmentId) : IRequest<Result<DepartmentDto, Error>>;