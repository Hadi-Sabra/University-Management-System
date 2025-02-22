namespace Core.DTOs;

public class EnrollmentDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public decimal? Grade { get; set; }
}