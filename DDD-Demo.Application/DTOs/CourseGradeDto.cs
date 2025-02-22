namespace Core.DTOs;

public class CourseGradeDto
{
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public decimal Grade { get; set; }
    public DateTime GradeDate { get; set; }
}