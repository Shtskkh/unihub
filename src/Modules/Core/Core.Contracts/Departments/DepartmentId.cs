namespace Core.Contracts.Departments;

public readonly record struct DepartmentId(int Id)
{
    public static DepartmentId Default => new(0);
}