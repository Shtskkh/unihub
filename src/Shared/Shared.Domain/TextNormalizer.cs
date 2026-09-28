using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Shared.Domain;

public static class TextNormalizer
{
    public static Result<string, Error> Normalize(string? text, Error nullOrWhitespaceError)
    {
        return string.IsNullOrWhiteSpace(text)
            ? Result<string, Error>.Failure(nullOrWhitespaceError)
            : Result<string, Error>.Success(text.Trim());
    }
}