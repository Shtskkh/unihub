using Core.Application.Shared;
using Core.Domain.Faculties;
using LightResults;

namespace Core.Application.Faculties.Create;

public sealed class CreateFacultyHandler(ICoreDbContext context) : IHandler<CreateFacultyCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateFacultyCommand request, CancellationToken ct)
    {
        var createFacultyTitleResult = FacultyTitle.Create(request.Title);

        if (createFacultyTitleResult.IsFailure(out var error))
            return Result.Failure<int>(error);

        createFacultyTitleResult.IsSuccess(out var facultyTitle);

        var newFaculty = new Faculty(default, facultyTitle);

        await context.Set<Faculty>().AddAsync(newFaculty, ct);
        await context.SaveChangesAsync(ct);

        return Result.Success(newFaculty.Id.Value);
    }
}