using Core.Contracts.Faculties;
using Core.Domain.Faculties;
using Core.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Context.Faculties.Configurations;

public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
{
    public void Configure(EntityTypeBuilder<Faculty> builder)
    {
        builder.ToTable("faculties");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(x => x.Value, value => new FacultyId(value))
            .HasColumnName("id")
            .IsRequired();

        builder.Property(e => e.Title)
            .HasConversion<ValueObjectConverter<FacultyTitle, string>>()
            .HasColumnName("title")
            .IsRequired();
    }
}