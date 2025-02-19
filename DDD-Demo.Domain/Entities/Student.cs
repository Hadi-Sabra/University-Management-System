
namespace Core.Domain.Entities;

public class Student : User
{
    private readonly List<Enrollment> _enrollments = new();
    public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();
    public decimal GradeAverage { get; private set; }
    public bool CanApplyToFrance { get; private set; }
    
    public Student(string firstName, string lastName, string email) 
        : base(firstName, lastName, email)
    {
        GradeAverage = 0;
        CanApplyToFrance = false;
    }
    
    public void EnrollInCourse(Course course, DateTime enrollmentDate)
    {
        // Check if already enrolled
        if (_enrollments.Any(e => e.CourseId == course.Id))
        {
            throw new InvalidOperationException("Student is already enrolled in this course");
        }
        
        // Check enrollment date is within allowed range
        if (enrollmentDate < course.EnrollmentStartDate || enrollmentDate > course.EnrollmentEndDate)
        {
            throw new InvalidOperationException("Enrollment date is outside the allowed range");
        }
        
        // Check if course has reached maximum capacity
        if (course.CurrentEnrollmentCount >= course.MaximumStudents)
        {
            throw new InvalidOperationException("Course has reached maximum capacity");
        }
        
        var enrollment = new Enrollment(this.Id, course.Id, enrollmentDate);
        _enrollments.Add(enrollment);
        course.IncrementEnrollmentCount();
    }
    
    public void UpdateGradeAverage()
    {
        if (_enrollments.Count == 0 || !_enrollments.Any(e => e.Grade.HasValue))
        {
            GradeAverage = 0;
            CanApplyToFrance = false;
            return;
        }
        
        var gradeSum = _enrollments.Where(e => e.Grade.HasValue).Sum(e => e.Grade.Value);
        var gradedCoursesCount = _enrollments.Count(e => e.Grade.HasValue);
        
        GradeAverage = gradeSum / gradedCoursesCount;
        CanApplyToFrance = GradeAverage > 15;
    }
    
    // For EF Core
    private Student() : base() { }
}