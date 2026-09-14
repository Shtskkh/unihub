using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniHub.Core.Contracts.Departments;
using UniHub.Core.Contracts.Faculties;
using UniHub.Core.Domain.Aggregates.Departments;

namespace UniHub.Core.Infrastructure.Context.Departments.Configurations;

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Value, value => new DepartmentId(value))
            .HasColumnName("id")
            .IsRequired();

        builder
            .Property(x => x.Title)
            .HasConversion(x => x.Value, value => new DepartmentTitle(value))
            .HasColumnName("title")
            .IsRequired();

        builder
            .Property(x => x.ShortTitle)
            .HasConversion(x => x.Value, value => new DepartmentShortTitle(value))
            .HasColumnName("short_title")
            .IsRequired();

        builder
            .Property(x => x.FacultyId)
            .HasConversion(x => x.Value, value => new FacultyId(value))
            .HasColumnName("faculty_id")
            .IsRequired();
    }
}
