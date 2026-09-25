using Microsoft.Extensions.DependencyInjection;

namespace Core.Application;

public static class CoreApplicationExtensions
{
    extension(IServiceCollection services)
    {
        public void AddCoreApplication()
        {
            services.AddRequestHandlers();
        }

        private void AddRequestHandlers()
        {
        }
    }
}