using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Shared.Domain;

public interface IValueObject<TSelf, TPrimitive>
    where TSelf : IValueObject<TSelf, TPrimitive>
{
    TPrimitive Value { get; }

    abstract static Result<TSelf, Error> Create(TPrimitive value);
}