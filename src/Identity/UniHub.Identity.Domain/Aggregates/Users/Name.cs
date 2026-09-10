namespace UniHub.Identity.Domain.Aggregates.Users;

public readonly record struct Name(string FirstName, string LastName, string? MiddleName);
