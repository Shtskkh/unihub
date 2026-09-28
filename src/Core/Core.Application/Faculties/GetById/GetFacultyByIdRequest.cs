using Core.Application.Shared;
using Core.Contracts.Faculties;
using Shared.Domain.Errors;
using ZeroAlloc.Results;

namespace Core.Application.Faculties.GetById;

public sealed record GetFacultyByIdRequest(int FacultyId) : IRequest<Result<FacultyDto, Error>>;