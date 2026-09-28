using Core.Application.Shared;
using Core.Contracts.Faculties;
using Core.Domain.Departments;
using Core.Domain.Faculties;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Errors;
using ZeroAlloc.Results;
using ZeroAlloc.Results.Extensions;

namespace Core.Application.Departments.Create;

public sealed class CreateDepartmentHandler(ICoreDbContext context)
    : IHandler<CreateDepartmentCommand, Result<int, Error>>
{
    public async Task<Result<int, Error>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var facultyId = new FacultyId(request.FacultyId);

        var departmentResult =
            from title in DepartmentTitle.Create(request.Title)
            select new Department(default, title, facultyId);

        return await departmentResult.BindAsync(async department =>
        {
            var isFacultyExists =
                await context.Set<Faculty>()
                    .AsNoTracking()
                    .AnyAsync(f => f.Id == facultyId, cancellationToken);

            if (!isFacultyExists)
                return Result<int, Error>.Failure(FacultyErrors.FacultyNotFoundById(request.FacultyId));

            await context.Set<Department>().AddAsync(department, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return Result<int, Error>.Success(department.Id.Value);
        });
    }
}