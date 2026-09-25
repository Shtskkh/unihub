using Core.Application.Faculties.Create;
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
            services.RegisterFacultiesHandlers();
        }

        private void RegisterFacultiesHandlers()
        {
            services.AddScoped<CreateFacultyHandler>();
        }
    }
}