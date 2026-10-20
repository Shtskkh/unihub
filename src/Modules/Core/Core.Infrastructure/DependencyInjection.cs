using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public void AddCoreInfrastructure(IConfiguration configuration)
        {
            services.ConfigureDbContext(configuration);
        }

        private void ConfigureDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(CoreDbContext.ConnectionStringName);

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException(
                    $"Строка подключения {CoreDbContext.ConnectionStringName} не сконфигурирована");

            services.AddDbContextPool<CoreDbContext>(options =>
            {
                options.UseNpgsql(connectionString,
                    n =>
                    {
                        n.MigrationsAssembly(typeof(CoreDbContext).Assembly.FullName);
                        n.MigrationsHistoryTable("__EFMigrationsHistory", CoreDbContext.Schema);
                    });
            });
        }
    }
}