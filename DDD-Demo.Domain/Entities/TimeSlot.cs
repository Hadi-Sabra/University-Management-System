namespace Core.Domain.Entities;

public class TimeSlot
{
    public Guid Id { get; private set; }
    public Guid TeacherCourseId { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    
    // Navigation property
    public TeacherCourse TeacherCourse { get; private set; }
    
    public TimeSlot(Guid teacherCourseId, DateTime startTime, DateTime endTime)
    {
        Id = Guid.NewGuid();
        TeacherCourseId = teacherCourseId;
        StartTime = startTime;
        EndTime = endTime;
    }
    
    // For EF Core
    private TimeSlot() { }
}