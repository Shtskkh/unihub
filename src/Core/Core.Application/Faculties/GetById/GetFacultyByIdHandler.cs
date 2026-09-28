using Core.Application.Shared;
using Core.Contracts.Faculties;
using Core.Domain.Faculties;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Faculties.GetById;

public sealed class GetFacultyByIdHandler(ICoreDbContext context)
    : IHandler<GetFacultyByIdCommand, Result<Faculty, Error>>
{
    public async Task<Result<Faculty, Error>> Handle(GetFacultyByIdCommand request, CancellationToken cancellationToken)
    {
        var requestId = new FacultyId(request.FacultyId);

        var faculty = await context.Set<Faculty>()
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == requestId, cancellationToken);

        return faculty is null
            ? Result<Faculty, Error>.Failure(FacultyErrors.FacultyNotFoundById(request.FacultyId))
            : Result<Faculty, Error>.Success(faculty);
    }
}