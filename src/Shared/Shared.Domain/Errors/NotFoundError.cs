namespace Shared.Domain.Errors;

public class NotFoundError(string code, string message) : DetailedError(code, message);