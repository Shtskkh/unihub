using Shared.Domain;
using Shared.Domain.Errors;
using ZeroAlloc.Results;
using ZeroAlloc.Results.Extensions;

namespace Identity.Domain.Users;

public readonly record struct FirstName : IValueObject<FirstName, string>
{
    private FirstName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<FirstName, Error> Create(string? value)
    {
        return TextNormalizer.Normalize(value, FirstNameErrors.NullOrWhiteSpace)
            .Map(normalized => new FirstName(normalized));
    }
}

public static class FirstNameErrors
{
    public readonly static Error NullOrWhiteSpace =
        Error.Validation($"{nameof(FirstName)}.{nameof(NullOrWhiteSpace)}", "Имя null или пусто.");
}