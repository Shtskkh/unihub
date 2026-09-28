using Core.Application.Shared;
using Core.Domain.Faculties;
using Shared.Domain.Errors;
using ZeroAlloc.Results;
using ZeroAlloc.Results.Extensions;

namespace Core.Application.Faculties.Create;

public sealed class CreateFacultyHandler(ICoreDbContext context) : IHandler<CreateFacultyCommand, Result<int, Error>>
{
    public async Task<Result<int, Error>> Handle(CreateFacultyCommand request, CancellationToken ct)
    {
        var facultyResult =
            from title in FacultyTitle.Create(request.Title)
            select new Faculty(default, title);

        return await facultyResult.MapAsync(async faculty =>
        {
            await context.Set<Faculty>().AddAsync(faculty, ct);
            await context.SaveChangesAsync(ct);

            return faculty.Id.Value;
        });
    }
}