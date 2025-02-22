namespace Core.DTOs.Requests;

public class SetGradeRequest
{
    public Guid CourseId { get; set; }
    public decimal Grade { get; set; }
}