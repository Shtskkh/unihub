using Core.Application.Shared;
using LightResults;

namespace Core.Application.Faculties.Create;

public sealed record CreateFacultyCommand(string Title) : IRequest<Result<int>>;