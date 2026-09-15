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
            services.ConfigureDbConnection(configuration);
        }

        private void ConfigureDbConnection(IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString(CoreDbContext.ConnectionStringName)
                ?? throw new InvalidOperationException(
                    "Строка подключения \"CoreDbConnection\" не сконфигурирована."
                );

            services.AddDbContextPool<CoreDbContext>(options =>
                options.UseNpgsql(
                    connectionString,
                    builder =>
                    {
                        builder.MigrationsHistoryTable(
                            "__EFMigrationsHistory",
                            CoreDbContext.Schema
                        );
                    }
                )
            );
        }
    }
}
