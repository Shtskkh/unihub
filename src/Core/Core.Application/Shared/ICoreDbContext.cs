using Microsoft.EntityFrameworkCore;

namespace Core.Application.Shared;

public interface ICoreDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}