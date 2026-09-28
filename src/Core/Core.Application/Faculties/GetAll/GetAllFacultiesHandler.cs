using Core.Application.Shared;
using Core.Contracts.Faculties;
using Core.Domain.Faculties;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Faculties.GetAll;

public class GetAllFacultiesHandler(ICoreDbContext context)
    : IHandler<GetAllFacultiesRequest, IReadOnlyCollection<FacultyDto>>
{
    public async Task<IReadOnlyCollection<FacultyDto>> Handle(GetAllFacultiesRequest request,
        CancellationToken cancellationToken)
    {
        var faculties = await context.Set<Faculty>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return faculties.Adapt<IReadOnlyCollection<FacultyDto>>();
    }
}