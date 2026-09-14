using Ardalis.SmartEnum;

namespace UniHub.Plans.Domain.Plans;

public sealed class EducationalForm : SmartEnum<EducationalForm>
{
    public static readonly EducationalForm FullTime = new(1, "Очное");
    public static readonly EducationalForm PartTime = new(2, "Очное-заочное");
    public static readonly EducationalForm Correspondence = new(3, "Заочное");

    private EducationalForm(int value, string name)
        : base(name, value) { }
}
