using Core.Application.Shared;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure;

public class CoreDbContext : DbContext, ICoreDbContext
{
    public const string DefaultSchema = "Core";
    public const string DefaultConnectionStringName = "CoreDbContext";

    public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DefaultSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreDbContext).Assembly);
    }
}