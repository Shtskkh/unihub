using Microsoft.EntityFrameworkCore;

namespace UniHub.Core.Infrastructure;

public class CoreDbContext : DbContext
{
    public CoreDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("core");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreDbContext).Assembly);
    }
}
