using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.Domain;

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
        if (TValueObject.Create(primitive).IsSuccess(out var valueObject))
            return valueObject;

        throw new InvalidOperationException(
            $"Значение '{primitive}' в БД не проходит валидацию {typeof(TValueObject).Name}. " +
            "Возможна порча данных или обход доменных инвариантов.");
    }
}