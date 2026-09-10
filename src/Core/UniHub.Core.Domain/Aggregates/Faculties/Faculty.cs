using UniHub.Shared.Classes;
using UniHub.Shared.Interfaces;

namespace UniHub.Core.Domain.Aggregates.Faculties;

public sealed class Faculty : Entity<FacultyId>, IAggregateRoot
{
    // Для EF Core
    private Faculty()
    {
    }

    public Faculty(FacultyId id, FacultyTitle title, FacultyShortTitle shortTitle, FacultyNumber number) : base(id)
    {
        Title = title;
        ShortTitle = shortTitle;
        Number = number;
    }

    public FacultyTitle Title { get; private set; }
    public FacultyShortTitle ShortTitle { get; private set; }
    public FacultyNumber Number { get; private set; }
}
