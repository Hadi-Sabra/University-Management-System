namespace Core.Domain.Entities;

public class Enrollment
{
    public Guid Id { get; private set; }
    public Guid StudentId { get; private set; }
    public Guid CourseId { get; private set; }
    public DateTime EnrollmentDate { get; private set; }
    public decimal? Grade { get; private set; }
    
    // Navigation properties
    public Student Student { get; private set; }
    public Course Course { get; private set; }
    
    public Enrollment(Guid studentId, Guid courseId, DateTime enrollmentDate)
    {
        Id = Guid.NewGuid();
        StudentId = studentId;
        CourseId = courseId;
        EnrollmentDate = enrollmentDate;
    }
    
    public void SetGrade(decimal grade)
    {
        if (grade < 0 || grade > 20)
        {
            throw new ArgumentException("Grade must be between 0 and 20");
        }
        
        Grade = grade;
    }
    
    // For EF Core
    private Enrollment() { }
}