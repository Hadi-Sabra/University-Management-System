using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectName.Persistance.Configuration;
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(c => c.MaximumStudents)
            .IsRequired();
        
        builder.Property(c => c.EnrollmentStartDate)
            .IsRequired();
        
        builder.Property(c => c.EnrollmentEndDate)
            .IsRequired();
    }
}