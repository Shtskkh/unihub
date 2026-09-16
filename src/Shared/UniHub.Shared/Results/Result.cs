using UniHub.Shared.Errors;

namespace UniHub.Shared.Results;

public class Result
{
    protected Result()
    {
        IsSuccess = true;
        Error = null;
    }

    protected Result(Error error)
    {
        ArgumentNullException.ThrowIfNull(error);

        IsSuccess = false;
        Error = error;
    }

    public bool IsSuccess { get; }
    public Error? Error { get; }

    public static Result Success() => new();

    public static Result Failure(Error error) => new(error);

    public static implicit operator Result(Error error) => new(error);
}
