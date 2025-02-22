namespace Core.DTOs.Requests;

public class UpdateCourseCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public int MaximumStudents { get; set; }
    public DateTime EnrollmentStartDate { get; set; }
    public DateTime EnrollmentEndDate { get; set; }
}
