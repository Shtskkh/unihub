using Core.Application.Shared;
using Core.Contracts.Faculties;
using Core.Domain.Faculties;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Faculties.GetById;

public sealed class GetFacultyByIdHandler(ICoreDbContext context)
    : IHandler<GetFacultyByIdRequest, Result<FacultyDto, Error>>
{
    public async Task<Result<FacultyDto, Error>> Handle(
        GetFacultyByIdRequest request,
        CancellationToken cancellationToken)
    {
        var requestId = new FacultyId(request.FacultyId);

        var faculty = await context.Set<Faculty>()
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == requestId, cancellationToken);

        return faculty is null
            ? Result<FacultyDto, Error>.Failure(FacultyErrors.FacultyNotFoundById(request.FacultyId))
            : Result<FacultyDto, Error>.Success(faculty.Adapt<FacultyDto>());
    }
}