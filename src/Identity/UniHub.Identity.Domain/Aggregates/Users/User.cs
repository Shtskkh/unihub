using UniHub.Shared.Classes;
using UniHub.Shared.Interfaces;

namespace UniHub.Identity.Domain.Aggregates.Users;

public sealed class User : Entity<UserId>, IAggregateRoot
{
    // Для EF Core
    private User()
    {
    }

    public User(
        UserId id,
        Name name,
        Email email,
        Login login,
        Password password,
        Birthday birthday,
        Gender gender
    ) : base(id)
    {
        Name = name;
        Email = email;
        Login = login;
        Password = password;
        Birthday = birthday;
        Gender = gender;
    }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Login Login { get; private set; }
    public Password Password { get; private set; }
    public Birthday Birthday { get; private set; }
    public Gender Gender { get; private set; } = null!;
}
