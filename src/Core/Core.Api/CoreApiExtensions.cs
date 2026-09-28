using Mapster;

namespace Core.Api;

public static class CoreApiExtensions
{
    extension(IServiceCollection services)
    {
        public void AddCoreApi()
        {
            TypeAdapterConfig.GlobalSettings.Scan(typeof(CoreApiExtensions).Assembly);
        }
    }
}