namespace Core.Domain.Entities;

public class Course
{
    private readonly List<TeacherCourse> _teacherCourses = new();
    public IReadOnlyCollection<TeacherCourse> TeacherCourses => _teacherCourses.AsReadOnly();
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Code { get; private set; }
    public int MaximumStudents { get; private set; }
    public DateTime EnrollmentStartDate { get; private set; }
    public DateTime EnrollmentEndDate { get; private set; }
    public int CurrentEnrollmentCount { get; private set; }
    
    public Course(string name, string code, int maximumStudents, 
        DateTime enrollmentStartDate, DateTime enrollmentEndDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        Code = code;
        MaximumStudents = maximumStudents;
        EnrollmentStartDate = enrollmentStartDate;
        EnrollmentEndDate = enrollmentEndDate;
        CurrentEnrollmentCount = 0;
    }
    
    public void IncrementEnrollmentCount()
    {
        if (CurrentEnrollmentCount >= MaximumStudents)
        {
            throw new InvalidOperationException("Course has reached maximum capacity");
        }
        
        CurrentEnrollmentCount++;
    }
    
    // For EF Core
    private Course() { }
}