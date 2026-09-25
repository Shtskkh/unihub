using Core.Contracts.Faculties;
using Shared.Domain;

namespace Core.Domain.Faculties;

public sealed class Faculty : Entity<FacultyId>, IAggregateRoot
{
    // Для EF Core
    private Faculty()
    {
    }

    public Faculty(FacultyId id, FacultyTitle title) : base(id)
    {
        Title = title;
    }

    public FacultyTitle Title { get; private set; }
}