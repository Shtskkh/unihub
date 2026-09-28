using Core.Application.Shared;
using Core.Contracts.Departments;
using Core.Contracts.Faculties;
using Core.Domain.Departments;
using Core.Domain.Faculties;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Faculties.GetDepartments;

public sealed class GetFacultyDepartmentsHandler(ICoreDbContext context)
    : IHandler<GetFacultyDepartmentsRequest, Result<IReadOnlyCollection<DepartmentDto>, Error>>
{
    public async Task<Result<IReadOnlyCollection<DepartmentDto>, Error>> Handle(
        GetFacultyDepartmentsRequest request,
        CancellationToken cancellationToken)
    {
        var facultyId = new FacultyId(request.FacultyId);
        var isFacultyExists = await context.Set<Faculty>()
            .AsNoTracking()
            .AnyAsync(f => f.Id == facultyId, cancellationToken);

        if (!isFacultyExists)
            return Result<IReadOnlyCollection<DepartmentDto>, Error>.Failure(
                FacultyErrors.FacultyNotFoundById(request.FacultyId));

        var departments = await context.Set<Department>()
            .AsNoTracking()
            .Where(d => d.FacultyId == facultyId)
            .ToListAsync(cancellationToken);

        var departmentsDto = departments.Adapt<IReadOnlyCollection<DepartmentDto>>();

        return Result<IReadOnlyCollection<DepartmentDto>, Error>.Success(departmentsDto);
    }
}