using Shared.Domain;
using Shared.Domain.Errors;
using ZeroAlloc.Results;
using ZeroAlloc.Results.Extensions;

namespace Identity.Domain.Users;

public readonly record struct LastName : IValueObject<LastName, string>
{
    private LastName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<LastName, Error> Create(string value)
    {
        return TextNormalizer.Normalize(value, LastNameErrors.NullOrWhiteSpace)
            .Map(normalized => new LastName(normalized));
    }
}

public static class LastNameErrors
{
    public readonly static Error NullOrWhiteSpace =
        Error.Validation($"{nameof(LastName)}.{nameof(NullOrWhiteSpace)}", "Фамилия null или пуста.");
}