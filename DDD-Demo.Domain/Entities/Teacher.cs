namespace Core.Domain.Entities;

public class Teacher : User
{
    private readonly List<TeacherCourse> _teacherCourses = new();
    public IReadOnlyCollection<TeacherCourse> TeacherCourses => _teacherCourses.AsReadOnly();

    public Teacher(string firstName, string lastName, string email) 
        : base(firstName, lastName, email)
    {
    }
    
    public void RegisterForCourse(Course course)
    {
        var existingRegistration = _teacherCourses.FirstOrDefault(tc => tc.CourseId == course.Id);
        if (existingRegistration != null)
        {
            return; // Already registered
        }
        
        var teacherCourse = new TeacherCourse(this.Id, course.Id);
        _teacherCourses.Add(teacherCourse);
    }
    
    public void AddTimeSlot(Course course, DateTime startTime, DateTime endTime)
    {
        var teacherCourse = _teacherCourses.FirstOrDefault(tc => tc.CourseId == course.Id);
        if (teacherCourse == null)
        {
            throw new InvalidOperationException("Teacher is not registered for this course");
        }
        
        teacherCourse.AddTimeSlot(startTime, endTime);
    }
    
    // For EF Core
    private Teacher() : base() { }
}