using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectName.Persistance.Configuration;


public class TeacherCourseConfiguration : IEntityTypeConfiguration<TeacherCourse>
{
    public void Configure(EntityTypeBuilder<TeacherCourse> builder)
    {
        builder.HasKey(tc => tc.Id);
        
        builder.HasOne(tc => tc.Teacher)
            .WithMany(t => t.TeacherCourses)
            .HasForeignKey(tc => tc.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(tc => tc.Course)
            .WithMany(c => c.TeacherCourses)
            .HasForeignKey(tc => tc.CourseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}