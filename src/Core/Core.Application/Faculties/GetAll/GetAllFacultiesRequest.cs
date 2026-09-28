using Core.Application.Shared;
using Core.Contracts.Faculties;

namespace Core.Application.Faculties.GetAll;

public sealed record GetAllFacultiesRequest : IRequest<IReadOnlyCollection<FacultyDto>>;