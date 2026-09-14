using UniHub.Plans.Contracts.Plans;
using UniHub.Plans.Contracts.Profiles;
using UniHub.Plans.Domain.Profiles;
using UniHub.Shared.Classes;
using UniHub.Shared.Interfaces;

namespace UniHub.Plans.Domain.Plans;

public sealed class Plan : Entity<PlanId>, IAggregateRoot
{
    // Для EF Core
    private Plan() { }

    public Plan(
        PlanId id,
        ProfileId profileId,
        EducationalForm educationalForm,
        IntakeYear intakeYear,
        DurationOfStudy duration,
        PlanStatus status
    )
        : base(id)
    {
        ProfileId = profileId;
        EducationalForm = educationalForm;
        IntakeYear = intakeYear;
        Duration = duration;
        Status = status;
    }

    public ProfileId ProfileId { get; private set; }
    public IntakeYear IntakeYear { get; private set; }
    public EducationalForm EducationalForm { get; private set; } = null!;
    public DurationOfStudy Duration { get; private set; }
    public PlanStatus Status { get; private set; } = null!;
}
