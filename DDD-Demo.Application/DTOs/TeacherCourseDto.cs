namespace Core.DTOs;

public class TeacherCourseDto
{
    public Guid Id { get; set; }
    public Guid TeacherId { get; set; }
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public ICollection<TimeSlotDto> TimeSlots { get; set; } = new List<TimeSlotDto>();
}