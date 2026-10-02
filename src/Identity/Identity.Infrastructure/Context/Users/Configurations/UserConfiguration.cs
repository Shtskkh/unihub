using Identity.Contracts.Users;
using Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrastructure;

namespace Identity.Infrastructure.Context.Users.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User).ToLower());

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(x => x.Value, value => new UserId(value))
            .HasColumnName("id")
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasConversion<ValueObjectConverter<FirstName, string>>()
            .HasColumnName("first_name")
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasConversion<ValueObjectConverter<LastName, string>>()
            .HasColumnName("last_name")
            .IsRequired();

        builder.Property(x => x.Gender)
            .HasConversion<int>()
            .HasColumnName("gender")
            .IsRequired();
    }
}