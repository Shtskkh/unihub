using LightResults;

namespace Shared.Domain;

public interface IValueObject<TSelf, TPrimitive>
    where TSelf : IValueObject<TSelf, TPrimitive>
{
    TPrimitive Value { get; }

    abstract static Result<TSelf> Create(TPrimitive value);
}