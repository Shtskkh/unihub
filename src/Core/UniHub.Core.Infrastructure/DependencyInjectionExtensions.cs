using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UniHub.Core.Infrastructure;

public static class DependencyInjectionExtensions
{
    extension(IServiceCollection services)
    {
        public void AddCoreInfrastructure(IConfiguration configuration)
        {
            services.ConfigureDbConnections(configuration);
        }

        private void ConfigureDbConnections(IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("CoreDbConnection")
                ?? throw new InvalidOperationException(
                    "Строка подключения \"CoreDbConnection\" не сконфигурирована."
                );

            services.AddDbContextPool<CoreDbContext>(options =>
                options.UseNpgsql(
                    connectionString,
                    builder =>
                    {
                        builder.MigrationsHistoryTable("__EFMigrationsHistory", "core");
                    }
                )
            );
        }
    }
}
