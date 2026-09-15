using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UniHub.Shared.Migrations;

public static class MigratorHost
{
    public static async Task RunAsync<TContext>(
        string[] args,
        string schema,
        string connectionStringName = "DbConnection",
        string migrationsHistoryTable = "__EFMigrationsHistory"
    )
        where TContext : DbContext
    {
        var builder = Host.CreateApplicationBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString(connectionStringName);

        if (builder.Environment.IsProduction())
            throw new InvalidOperationException(
                "Не используйте мигратор в продакшее, используйте efbundle."
            );

        if (connectionString is null)
            throw new InvalidOperationException(
                $"Отсутствует строка подключения: {connectionStringName}"
            );

        builder.Services.AddDbContext<TContext>(options =>
            options.UseNpgsql(
                connectionString,
                npgsql =>
                {
                    npgsql.MigrationsAssembly(typeof(TContext).Assembly.GetName().Name);
                    npgsql.MigrationsHistoryTable(migrationsHistoryTable, schema);
                }
            )
        );

        builder.Services.AddHostedService<MigrationWorker<TContext>>();

        await builder.Build().RunAsync();
    }
}
