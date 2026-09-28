using Core.Application.Departments.Create;
using Core.Application.Departments.GetById;
using Core.Application.Faculties.Create;
using Core.Application.Faculties.GetAll;
using Core.Application.Faculties.GetById;
using Core.Application.Faculties.GetDepartments;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application;

public static class CoreApplicationExtensions
{
    extension(IServiceCollection services)
    {
        public void AddCoreApplication()
        {
            TypeAdapterConfig.GlobalSettings.Scan(typeof(CoreApplicationExtensions).Assembly);
            services.AddMapster();
            services.AddRequestHandlers();
        }

        private void AddRequestHandlers()
        {
            services.RegisterFacultiesHandlers();
            services.RegisterDepartmentsHandlers();
        }

        private void RegisterFacultiesHandlers()
        {
            services.AddScoped<CreateFacultyHandler>();
            services.AddScoped<GetAllFacultiesHandler>();
            services.AddScoped<GetFacultyByIdHandler>();
            services.AddScoped<GetFacultyDepartmentsHandler>();
        }

        private void RegisterDepartmentsHandlers()
        {
            services.AddScoped<CreateDepartmentHandler>();
            services.AddScoped<GetDepartmentByIdHandler>();
        }
    }
}