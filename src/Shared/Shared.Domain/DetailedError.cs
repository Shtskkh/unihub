using LightResults;

namespace Shared.Domain;

public class DetailedError : Error
{
    public DetailedError(string code, string message)
        : base(message, new Dictionary<string, object?>
        {
            ["code"] = code
        })
    {
        Code = code;
    }

    public string Code { get; }
}