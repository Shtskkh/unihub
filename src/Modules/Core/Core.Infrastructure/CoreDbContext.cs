using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure;

public sealed class CoreDbContext : DbContext
{
    public const string Schema = "core";
    public const string ConnectionStringName = "CoreDbContext";

    public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreDbContext).Assembly);
    }
}