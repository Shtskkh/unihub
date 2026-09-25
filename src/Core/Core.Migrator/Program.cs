using Core.Infrastructure;
using Shared.Migrator;

await MigratorHost.RunAsync<CoreDbContext>(
    args,
    CoreDbContext.DefaultSchema,
    CoreDbContext.DefaultConnectionStringName
);