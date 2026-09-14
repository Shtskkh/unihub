using UniHub.Plans.Contracts.Programs;
using UniHub.Shared.Classes;
using UniHub.Shared.Interfaces;

namespace UniHub.Plans.Domain.Programs;

public sealed class EducationalProgram : Entity<EducationalProgramId>, IAggregateRoot
{
    // Для EF Core
    private EducationalProgram() { }

    public EducationalProgram(EducationalProgramId id, ProgramCode code, ProgramTitle title)
        : base(id)
    {
        Code = code;
        Title = title;
    }

    public ProgramCode Code { get; private set; }
    public ProgramTitle Title { get; private set; }
}
