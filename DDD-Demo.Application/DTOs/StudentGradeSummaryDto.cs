namespace Core.DTOs;

public class StudentGradeSummaryDto
{
    public Guid StudentId { get; set; }
    public string StudentName { get; set; }
    public decimal GradeAverage { get; set; }
    public bool CanApplyToFrance { get; set; }
    public ICollection<CourseGradeDto> CourseGrades { get; set; } = new List<CourseGradeDto>();
}