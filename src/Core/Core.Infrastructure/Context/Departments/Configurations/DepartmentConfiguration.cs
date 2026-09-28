using Core.Contracts.Departments;
using Core.Contracts.Faculties;
using Core.Domain.Departments;
using Core.Domain.Faculties;
using Core.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Context.Departments.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(x => x.Value, value => new DepartmentId(value))
            .HasColumnName("id")
            .IsRequired();

        builder.Property(x => x.Title)
            .HasConversion<ValueObjectConverter<DepartmentTitle, string>>()
            .HasColumnName("title")
            .IsRequired();

        builder.Property(x => x.FacultyId)
            .HasConversion(x => x.Value, value => new FacultyId(value))
            .HasColumnName("faculty_id")
            .IsRequired();
        
        builder.HasOne<Faculty>()
            .WithMany()
            .HasForeignKey(x => x.FacultyId)
            .HasConstraintName("FK_departments_faculties")
            .OnDelete(DeleteBehavior.Restrict);
    }
}