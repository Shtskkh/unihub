using UniHub.Core.Infrastructure;
using UniHub.Shared.Migrations;

await MigratorHost.RunAsync<CoreDbContext>(
    args,
    CoreDbContext.Schema,
    CoreDbContext.ConnectionStringName
);
