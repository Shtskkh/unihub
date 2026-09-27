using LightResults;

namespace Shared.Domain;

public static class ResultMatchExtensions
{
    extension(Result result)
    {
        public TOut Match<TOut>(Func<TOut> onSuccess, Func<IError, TOut> onFailure)
        {
            return result.IsFailure(out var error) ? onFailure(error) : onSuccess();
        }
    }

    extension<T>(Result<T> result)
    {
        public TOut Match<TOut>(Func<T, TOut> onSuccess, Func<IError, TOut> onFailure)
        {
            return result.IsSuccess(out var value) ? onSuccess(value) : onFailure(GetSingleError(result));
        }
    }

    private static IError GetSingleError<T>(Result<T> result)
    {
        return result.IsFailure(out var error)
            ? error
            : throw new InvalidOperationException("Result ожидался failure, но оказался success.");
    }
}