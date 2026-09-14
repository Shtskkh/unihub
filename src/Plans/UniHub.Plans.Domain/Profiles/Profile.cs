using UniHub.Plans.Contracts.Profiles;
using UniHub.Plans.Contracts.Programs;
using UniHub.Shared.Classes;
using UniHub.Shared.Interfaces;

namespace UniHub.Plans.Domain.Profiles;

public sealed class Profile : Entity<ProfileId>, IAggregateRoot
{
    // Для EF Core
    private Profile() { }

    public Profile(ProfileId id, ProfileTitle title, EducationalProgramId programId)
        : base(id)
    {
        Title = title;
        ProgramId = programId;
    }

    public ProfileTitle Title { get; private set; }
    public EducationalProgramId ProgramId { get; private set; }
}
