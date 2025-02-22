namespace Core.DTOs;

public class EnrollmentStatisticsDto
{
    public int TotalStudents { get; set; }
    public int TotalCourses { get; set; }
    public double AverageEnrollmentPerCourse { get; set; }
    public IDictionary<string, int> EnrollmentsByCourse { get; set; } = new Dictionary<string, int>();
    public IDictionary<string, int> StudentEnrollmentCounts { get; set; } = new Dictionary<string, int>();
}