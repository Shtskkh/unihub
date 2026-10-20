namespace UniHub.SharedKernel;

public abstract class Entity<TId> where TId : struct, IEquatable<TId>
{
    public TId Id { get; protected init; }
}