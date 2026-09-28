using Core.Contracts.Departments;
using Core.Contracts.Faculties;
using Shared.Domain;
using Shared.Domain.Errors;

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

public static class DepartmentErrors
{
    public static Error NotFoundById(int id)
    {
        return Error.NotFound("Department.NotFoundById", $"Кафедра с ID: {id} не найдена.");
    }
}