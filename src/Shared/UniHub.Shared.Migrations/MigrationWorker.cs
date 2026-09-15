using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace UniHub.Shared.Migrations;

public sealed class MigrationWorker<TContext>(
    IServiceProvider serviceProvider,
    IHostApplicationLifetime applicationLifetime,
    ILogger<MigrationWorker<TContext>> logger
) : BackgroundService
    where TContext : DbContext
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await using var scope = serviceProvider.CreateAsyncScope();
            var context = scope.ServiceProvider.GetRequiredService<TContext>();

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation(
                    "\nПрименение миграций для {TContext}.\n",
                    typeof(TContext).Name
                );

            await context.Database.MigrateAsync(stoppingToken);

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation(
                    "\nМиграции применены для {TContext}.\n",
                    typeof(TContext).Name
                );
        }
        catch (Exception e)
        {
            logger.LogError(
                e,
                "\nПроизошла ошибка миграций для {TContext}.\n",
                typeof(TContext).Name
            );
            throw;
        }
        finally
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Применены миграции для {TContext}.", typeof(TContext).Name);

            applicationLifetime.StopApplication();
        }
    }
}
