using Core.Application.Shared;
using Core.Domain.Faculties;

namespace Core.Application.Faculties.GetAll;

public sealed record GetAllFacultiesRequest : IRequest<IReadOnlyCollection<Faculty>>;