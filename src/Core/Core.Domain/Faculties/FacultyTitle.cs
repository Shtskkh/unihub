using LightResults;
using Shared.Domain;
using Shared.Domain.Errors;

namespace Core.Domain.Faculties;

public readonly record struct FacultyTitle : IValueObject<FacultyTitle, string>
{
    private FacultyTitle(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<FacultyTitle> Create(string? text)
    {
        var normalized = TextNormalizer.Normalize(text, FacultyTitleErrors.NullOrWhiteSpace);

        if (normalized.IsFailure(out var error))
            return Result.Failure<FacultyTitle>(error);

        normalized.IsSuccess(out var value);

        return Result.Success(new FacultyTitle(value!));
    }
};

public static class FacultyTitleErrors
{
    public readonly static ValidationError NullOrWhiteSpace =
        new("FacultyTitle.NullOrWhiteSpace", "Название факультета null или пусто.");
}