namespace Core.Domain.Entities;

public class TeacherCourse
{
    private readonly List<TimeSlot> _timeSlots = new();
    public IReadOnlyCollection<TimeSlot> TimeSlots => _timeSlots.AsReadOnly();
    
    public Guid Id { get; private set; }
    public Guid TeacherId { get; private set; }
    public Guid CourseId { get; private set; }
    
    // Navigation properties
    public Teacher Teacher { get; private set; }
    public Course Course { get; private set; }
    
    public TeacherCourse(Guid teacherId, Guid courseId)
    {
        Id = Guid.NewGuid();
        TeacherId = teacherId;
        CourseId = courseId;
    }
    
    public void AddTimeSlot(DateTime startTime, DateTime endTime)
    {
        if (startTime >= endTime)
        {
            throw new ArgumentException("Start time must be before end time");
        }
        
        // Check for overlapping time slots
        foreach (var existingSlot in _timeSlots)
        {
            if (startTime < existingSlot.EndTime && existingSlot.StartTime < endTime)
            {
                throw new InvalidOperationException("New time slot overlaps with existing time slot");
            }
        }
        
        var timeSlot = new TimeSlot(this.Id, startTime, endTime);
        _timeSlots.Add(timeSlot);
    }
    
    // For EF Core
    private TeacherCourse() { }
}