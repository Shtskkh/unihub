using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniHub.Core.Contracts.Faculties;
using UniHub.Core.Domain.Aggregates.Faculties;

namespace UniHub.Core.Infrastructure.Context.Faculties.Configurations;

public sealed class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.ToTable("faculties");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Value, value => new FacultyId(value))
            .HasColumnName("id")
            .IsRequired();

        builder
            .Property(x => x.Title)
            .HasConversion(x => x.Value, x => new FacultyTitle(x))
            .HasColumnName("title")
            .IsRequired();

        builder
            .Property(x => x.ShortTitle)
            .HasConversion(x => x.Value, x => new FacultyShortTitle(x))
            .HasColumnName("short_title")
            .IsRequired();

        builder
            .Property(x => x.Number)
            .HasConversion(x => x.Value, x => new FacultyNumber(x))
            .HasColumnName("number")
            .IsRequired();
    }
}
