using Core.Contracts.Departments;
using Core.Contracts.Faculties;
using UniHub.SharedKernel;
using ZeroAlloc.Results;

namespace Core.Domain.Departments;

public sealed class Department : Entity<DepartmentId>
{
    // Для EF Core
    private Department()
    {
    }

    public string Title { get; private set; } = null!;

    public FacultyId FacultyId { get; private set; }

    public static Result<Department> Create(DepartmentId id, FacultyId facultyId, string title)
    {
        var department = new Department
        {
            Id = id,
            FacultyId = facultyId,
            Title = title
        };

        return Result<Department>.Success(department);
    }
}