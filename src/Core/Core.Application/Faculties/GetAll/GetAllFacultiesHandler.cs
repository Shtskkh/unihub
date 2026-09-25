using Core.Application.Shared;
using Core.Domain.Faculties;
using LightResults;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Faculties.GetAll;

public class GetAllFacultiesHandler(ICoreDbContext context)
    : IHandler<GetAllFacultiesRequest, Result<IReadOnlyCollection<Faculty>>>
{
    public async Task<Result<IReadOnlyCollection<Faculty>>> Handle(GetAllFacultiesRequest request,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Faculty> faculties = await context.Set<Faculty>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return Result.Success(faculties);
    }
}