using Core.Application.Shared;
using Core.Contracts.Departments;
using Core.Domain.Departments;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Departments.GetById;

public sealed class GetDepartmentByIdHandler(ICoreDbContext context)
    : IHandler<GetDepartmentByIdRequest, Result<DepartmentDto, Error>>
{
    public async Task<Result<DepartmentDto, Error>> Handle(
        GetDepartmentByIdRequest request,
        CancellationToken cancellationToken)
    {
        var departmentId = new DepartmentId(request.DepartmentId);

        var department = await context.Set<Department>()
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == departmentId, cancellationToken);

        return department is null
            ? Result<DepartmentDto, Error>.Failure(DepartmentErrors.NotFoundById(request.DepartmentId))
            : Result<DepartmentDto, Error>.Success(department.Adapt<DepartmentDto>());
    }
}