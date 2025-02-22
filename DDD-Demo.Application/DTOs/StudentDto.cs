namespace Core.DTOs;

public class StudentDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public decimal GradeAverage { get; set; }
    public bool CanApplyToFrance { get; set; }
    public ICollection<EnrollmentDto> Enrollments { get; set; } = new List<EnrollmentDto>();
}