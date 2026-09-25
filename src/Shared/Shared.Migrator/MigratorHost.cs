using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Shared.Migrator;

public static class MigratorHost
{
    public static async Task RunAsync<TContext>(
        string[] args,
        string schema,
        string connectionStringName = "DbConnection",
        string migrationsHistoryTable = "__EFMigrationsHistory",
        CancellationToken cancellationToken = default
    )
        where TContext : DbContext
    {
        var builder = Host.CreateApplicationBuilder(args);

        if (builder.Environment.IsProduction())
            throw new InvalidOperationException(
                "Не используйте мигратор в продакшене. Используйте efbundle."
            );

        var connectionString = builder.Configuration.GetConnectionString(connectionStringName);

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

        builder.Services.AddScoped<MigrationRunner<TContext>>();

        using var host = builder.Build();
        await using var scope = host.Services.CreateAsyncScope();

        try
        {
            var runner = scope.ServiceProvider.GetRequiredService<MigrationRunner<TContext>>();
            await runner.RunAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            Environment.ExitCode = 130;
        }
        catch (Exception e)
        {
            var logger = scope.ServiceProvider.GetRequiredService<
                ILogger<MigrationRunner<TContext>>
            >();

            logger.LogError(
                e,
                "Ошибка при применении миграций для {Context}",
                typeof(TContext).Name
            );

            Environment.ExitCode = -1;
        }
    }
}