namespace Shared.Domain.Errors;

public readonly record struct Error
{
    private Error(ErrorType type, string code, string message)
    {
        Type = type;
        Code = code;
        Message = message;
    }

    public ErrorType Type { get; }

    public string Code { get; }

    public string Message { get; }

    public static Error Unexpected(string code, string message)
    {
        return new Error(ErrorType.Unexpected, code, message);
    }

    public static Error Validation(string code, string message)
    {
        return new Error(ErrorType.Validation, code, message);
    }

    public static Error NotFound(string code, string message)
    {
        return new Error(ErrorType.NotFound, code, message);
    }
};