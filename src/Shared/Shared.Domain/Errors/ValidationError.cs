using LightResults;

namespace Shared.Domain.Errors;

public sealed class ValidationError(string code, string message)
    : Error(message, (code, message));