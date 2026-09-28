using Shared.Domain;
using Shared.Domain.Errors;
using ZeroAlloc.Results;
using ZeroAlloc.Results.Extensions;

namespace Core.Domain.Faculties;

public readonly record struct FacultyTitle : IValueObject<FacultyTitle, string>
{
    private FacultyTitle(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<FacultyTitle, Error> Create(string? text)
    {
        return TextNormalizer.Normalize(text, FacultyTitleErrors.NullOrWhiteSpace)
            .Map(normalized => new FacultyTitle(normalized));
    }
};

public static class FacultyTitleErrors
{
    public readonly static Error NullOrWhiteSpace =
        Error.Validation("FacultyTitle.NullOrWhiteSpace", "Название факультета null или пусто.");
}