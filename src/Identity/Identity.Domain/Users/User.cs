using Identity.Contracts.Users;
using Shared.Domain;

namespace Identity.Domain.Users;

public sealed class User : Entity<UserId>, IAggregateRoot
{
    // Для EF Core
    private User()
    {
    }

    public User(UserId userId, FirstName firstName, LastName lastName, Gender gender) : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
    }

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public Gender Gender { get; }
}