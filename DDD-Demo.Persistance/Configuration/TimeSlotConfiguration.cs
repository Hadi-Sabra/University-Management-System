using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectName.Persistance.Configuration;

public class TimeSlotConfiguration : IEntityTypeConfiguration<TimeSlot>
{
    public void Configure(EntityTypeBuilder<TimeSlot> builder)
    {
        builder.HasKey(ts => ts.Id);
        
        builder.Property(ts => ts.StartTime)
            .IsRequired();
        
        builder.Property(ts => ts.EndTime)
            .IsRequired();
        
        builder.HasOne(ts => ts.TeacherCourse)
            .WithMany(tc => tc.TimeSlots)
            .HasForeignKey(ts => ts.TeacherCourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
