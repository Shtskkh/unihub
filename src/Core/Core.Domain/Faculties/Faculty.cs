using Core.Contracts.Faculties;
using Shared.Domain;
using Shared.Domain.Errors;

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

public static class FacultyErrors
{
    public static NotFoundError FacultyNotFoundById(int id)
    {
        return new NotFoundError("Faculty.NotFoundById", $"Факультет с ID: {id} не найден.");
    }
}