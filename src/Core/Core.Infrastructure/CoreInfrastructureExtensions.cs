using Core.Application.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure;

public static class CoreInfrastructureExtensions
{
    extension(IServiceCollection services)
    {
        public void AddCoreInfrastructure(IConfiguration configuration)
        {
            services.ConfigureDbContext(configuration);
            services.AddDbContextProvider();
        }

        private void ConfigureDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(CoreDbContext.DefaultConnectionStringName);
            if (connectionString == null)
                throw new InvalidOperationException(
                    $"Строка подключения {CoreDbContext.DefaultConnectionStringName} не сконфигурирована.");

            services.AddDbContextPool<CoreDbContext>(options => options.UseNpgsql(connectionString,
                builder =>
                {
                    builder.MigrationsAssembly(typeof(CoreDbContext).Assembly.FullName);
                    builder.MigrationsHistoryTable("__EFMigrationsHistory", CoreDbContext.DefaultSchema);
                }));
        }

        private void AddDbContextProvider()
        {
            services.AddScoped<ICoreDbContext, CoreDbContext>();
        }
    }
}