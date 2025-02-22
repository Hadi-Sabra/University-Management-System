namespace Core.DTOs;

public class CourseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int MaximumStudents { get; set; }
    public DateTime EnrollmentStartDate { get; set; }
    public DateTime EnrollmentEndDate { get; set; }
    public int CurrentEnrollmentCount { get; set; }
    public ICollection<TimeSlotDto> AvailableTimeSlots { get; set; } = new List<TimeSlotDto>();
}
