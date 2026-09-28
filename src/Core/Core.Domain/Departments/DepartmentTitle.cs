using Shared.Domain;
using Shared.Domain.Errors;
using ZeroAlloc.Results;
using ZeroAlloc.Results.Extensions;

namespace Core.Domain.Departments;

public readonly record struct DepartmentTitle : IValueObject<DepartmentTitle, string>
{
    private DepartmentTitle(string title)
    {
        Value = title;
    }

    public string Value { get; }

    public static Result<DepartmentTitle, Error> Create(string? value)
    {
        return TextNormalizer.Normalize(value, DepartmentTitleErrors.NullOrWhiteSpace)
            .Map(normalized => new DepartmentTitle(normalized));
    }
}

public static class DepartmentTitleErrors
{
    public readonly static Error NullOrWhiteSpace =
        Error.Validation("DepartmentTitle.NullOrWhiteSpace", "Название кафедры null или пусто.");
}