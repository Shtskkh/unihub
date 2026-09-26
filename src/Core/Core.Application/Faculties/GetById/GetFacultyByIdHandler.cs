using Core.Application.Shared;
using Core.Contracts.Faculties;
using Core.Domain.Faculties;
using LightResults;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Faculties.GetById;

public sealed class GetFacultyByIdHandler(ICoreDbContext context) : IHandler<GetFacultyByIdCommand, Result<Faculty>>
{
    public async Task<Result<Faculty>> Handle(GetFacultyByIdCommand request, CancellationToken cancellationToken)
    {
        var requestId = new FacultyId(request.FacultyId);

        var faculty = await context.Set<Faculty>()
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == requestId, cancellationToken);

        if (faculty == null)
            return Result.Failure<Faculty>(FacultyErrors.FacultyNotFoundById(request.FacultyId));

        return Result.Success(faculty);
    }
}