using Core.Application.Shared;
using Core.Domain.Faculties;
using LightResults;

namespace Core.Application.Faculties.GetAll;

public sealed record GetAllFacultiesRequest : IRequest<Result<IReadOnlyCollection<Faculty>>>;