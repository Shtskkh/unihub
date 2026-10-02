using Identity.Infrastructure;
using Shared.Migrator;

await MigratorHost.RunAsync<IdentityDbContext>(
    args,
    IdentityDbContext.DefaultSchema,
    IdentityDbContext.DefaultConnectionStringName
);