namespace Shared.Domain.Errors;

public sealed class ValidationError(string code, string message) : DetailedError(code, message);