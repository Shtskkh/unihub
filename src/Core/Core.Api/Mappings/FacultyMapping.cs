using Core.Api.Contracts.Faculties;
using Core.Domain.Faculties;
using Mapster;

namespace Core.Api.Mappings;

public sealed class FacultyMappingConfigs : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Faculty, FacultyDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Title, src => src.Title.Value);
    }
}