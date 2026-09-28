using Core.Contracts.Departments;
using Core.Contracts.Faculties;
using Shared.Domain;

namespace Core.Domain.Departments;

public sealed class Department : Entity<DepartmentId>, IAggregateRoot
{
    // Для EF Core
    private Department()
    {
    }

    public Department(DepartmentId id, DepartmentTitle title, FacultyId facultyId) : base(id)
    {
        Title = title;
        FacultyId = facultyId;
    }

    public DepartmentTitle Title { get; private set; }

    public FacultyId FacultyId { get; private set; }
}