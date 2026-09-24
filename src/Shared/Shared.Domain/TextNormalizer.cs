using LightResults;
using Shared.Domain.Errors;

namespace Shared.Domain;

public static class TextNormalizer
{
    public static Result<string> Normalize(string? text, ValidationError nullOrWhitespaceError)
    {
        if (string.IsNullOrWhiteSpace(text))
            return Result.Failure<string>(nullOrWhitespaceError);

        var trimmed = text.Trim();

        return Result.Success(trimmed);
    }
}