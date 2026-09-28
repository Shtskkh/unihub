using Shared.Domain.Errors;
using ZeroAlloc.Results;
using ZeroAlloc.Results.Extensions;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace Core.Api.Shared;

public static class ResultHttpExtensions
{
    extension<T>(Result<T, Error> result)
    {
        public IResult ToHttpResult(Func<T, IResult> onSuccess)
        {
            return result.Match(onSuccess, ToErrorResult);
        }
    }

    private static IResult ToErrorResult(Error error)
    {
        return error.Type switch
        {
            ErrorType.NotFound => Results.NotFound(error.Message),
            ErrorType.Validation => Results.BadRequest(error.Message),
            _ => Results.InternalServerError(error.Message)
        };
    }
}