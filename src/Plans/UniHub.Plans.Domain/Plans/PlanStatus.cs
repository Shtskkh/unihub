using Ardalis.SmartEnum;

namespace UniHub.Plans.Domain.Plans;

public sealed class PlanStatus : SmartEnum<PlanStatus>
{
    public static readonly PlanStatus Draft = new(1, "Черновик");
    public static readonly PlanStatus Active = new(2, "Активен");
    public static readonly PlanStatus Superseded = new(3, "Заменён");

    private PlanStatus(int value, string name)
        : base(name, value) { }
}
