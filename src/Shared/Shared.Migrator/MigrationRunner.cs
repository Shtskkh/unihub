using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Shared.Migrator;

public sealed class MigrationRunner<TContext>(
    TContext context,
    ILogger<MigrationRunner<TContext>> logger
)
    where TContext : DbContext
{
    internal async Task RunAsync(CancellationToken stoppingToken)
    {
        if (logger.IsEnabled(LogLevel.Information))
            logger.LogInformation("\nПрименение миграций для {TContext}.\n", typeof(TContext).Name);

        await context.Database.MigrateAsync(stoppingToken);

        if (logger.IsEnabled(LogLevel.Information))
            logger.LogInformation("\nМиграции применены для {TContext}.\n", typeof(TContext).Name);
    }
}