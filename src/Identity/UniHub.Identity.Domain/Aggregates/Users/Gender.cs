using Ardalis.SmartEnum;

namespace UniHub.Identity.Domain.Aggregates.Users;

public class Gender : SmartEnum<Gender>
{
    public static readonly Gender Male = new(1, "Мужской");
    public static readonly Gender Female = new(2, "Женский");

    private Gender(int id, string value)
        : base(value, id) { }
}
