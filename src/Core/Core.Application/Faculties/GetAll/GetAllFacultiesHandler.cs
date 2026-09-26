using Core.Application.Shared;
using Core.Domain.Faculties;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Faculties.GetAll;

public class GetAllFacultiesHandler(ICoreDbContext context)
    : IHandler<GetAllFacultiesRequest, IReadOnlyCollection<Faculty>>
{
    public async Task<IReadOnlyCollection<Faculty>> Handle(GetAllFacultiesRequest request,
        CancellationToken cancellationToken)
    {
        var faculties = await context.Set<Faculty>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return faculties.AsReadOnly();
    }
}