using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure;

public static class IdentityInfrastructureExtensions
{
    extension(IServiceCollection services)
    {
        public void AddIdentityInfrastructure(IConfiguration configuration)
        {
            services.ConfigureDbContext(configuration);
        }

        private void ConfigureDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(IdentityDbContext.DefaultConnectionStringName);

            if (connectionString == null)
                throw new InvalidOperationException(
                    $"Строка подключения {IdentityDbContext.DefaultConnectionStringName} не сконфигурирована.");

            services.AddDbContextPool<IdentityDbContext>(options => options.UseNpgsql(connectionString,
                builder =>
                {
                    builder.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName);
                    builder.MigrationsHistoryTable("__EFMigrationsHistory", IdentityDbContext.DefaultSchema);
                }));
        }
    }
}