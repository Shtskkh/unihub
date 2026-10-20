namespace UniHub.BuildingBlocks.Application.CQRS;

public interface IQueryHandler<in TQuery, TResult>
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken ct);
}