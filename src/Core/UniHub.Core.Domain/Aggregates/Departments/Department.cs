using UniHub.Core.Contracts.Departments;
using UniHub.Core.Contracts.Faculties;
using UniHub.Shared.Classes;
using UniHub.Shared.Interfaces;

namespace UniHub.Core.Domain.Aggregates.Departments;

public sealed class Department : Entity<DepartmentId>, IAggregateRoot
{
    // Для EF Core
    private Department() { }

    public Department(
        DepartmentId id,
        FacultyId facultyId,
        DepartmentTitle title,
        DepartmentShortTitle shortTitle
    )
        : base(id)
    {
        FacultyId = facultyId;
        Title = title;
        ShortTitle = shortTitle;
    }

    public FacultyId FacultyId { get; private set; }
    public DepartmentTitle Title { get; private set; }
    public DepartmentShortTitle ShortTitle { get; private set; }
}
