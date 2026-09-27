using LightResults;
using Shared.Domain;
using Shared.Domain.Errors;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace Core.Api.Shared;

public static class ResultHttpExtensions
{
    extension(Result result)
    {
        public IResult ToHttpResult(Func<IResult> onSuccess)
        {
            return result.Match(onSuccess, ToErrorResult);
        }

        public IResult ToHttpResult()
        {
            return result.ToHttpResult(Results.NoContent);
        }
    }

    extension<T>(Result<T> result)
    {
        public IResult ToHttpResult(Func<T, IResult> onSuccess)
        {
            return result.Match(onSuccess, ToErrorResult);
        }
    }

    private static IResult ToErrorResult(IError error)
    {
        return error switch
        {
            NotFoundError notFoundError => Results.NotFound(notFoundError.Message),
            ValidationError validationError => Results.BadRequest(validationError.Message),
            _ => Results.InternalServerError(error.Message)
        };
    }
}