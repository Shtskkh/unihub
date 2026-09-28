using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.Domain;
using ZeroAlloc.Results.Extensions;

namespace Core.Infrastructure.Shared;

public sealed class ValueObjectConverter<TValueObject, TPrimitive> : ValueConverter<TValueObject, TPrimitive>
    where TValueObject : IValueObject<TValueObject, TPrimitive>
{
    public ValueObjectConverter()
        : base(
            valueObject => valueObject.Value,
            primitive => FromDatabase(primitive)
        )
    {
    }

    private static TValueObject FromDatabase(TPrimitive primitive)
    {
        return TValueObject.Create(primitive).Match(
            valueObject => valueObject,
            error => throw new InvalidOperationException(
                $"Значение '{primitive}' в БД не проходит валидацию {typeof(TValueObject).Name}: " +
                $"[{error.Code}] {error.Message}. " +
                "Возможна порча данных или обход доменных инвариантов."));
    }
}