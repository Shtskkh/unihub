namespace Core.Contracts.Faculties;

public readonly record struct FacultyId(int Id)
{
    public static FacultyId Default => new(0);
}