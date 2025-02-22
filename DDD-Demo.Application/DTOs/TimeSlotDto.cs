namespace Core.DTOs;

public class TimeSlotDto
{
    public Guid Id { get; set; }
    public Guid TeacherCourseId { get; set; }
    public Guid TeacherId { get; set; }
    public string TeacherName { get; set; }
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DayOfWeek DayOfWeek => StartTime.DayOfWeek;
}