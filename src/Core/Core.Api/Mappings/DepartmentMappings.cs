using Core.Contracts.Departments;
using Core.Domain.Departments;
using Mapster;

namespace Core.Api.Mappings;

public sealed class DepartmentMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Department, DepartmentDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Title, src => src.Title.Value);
    }
}