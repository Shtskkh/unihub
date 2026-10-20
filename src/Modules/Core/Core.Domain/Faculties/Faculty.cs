using Core.Contracts.Faculties;
using UniHub.SharedKernel;
using ZeroAlloc.Results;

namespace Core.Domain.Faculties;

public sealed class Faculty : Entity<FacultyId>
{
    // Для EF Core
    private Faculty()
    {
    }

    public string Title { get; private set; } = null!;

    public static Result<Faculty> Create(FacultyId facultyId, string title)
    {
        var faculty = new Faculty
        {
            Id = facultyId,
            Title = title
        };

        return Result<Faculty>.Success(faculty);
    }
}