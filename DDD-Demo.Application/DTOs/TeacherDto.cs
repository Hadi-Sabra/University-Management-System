namespace Core.DTOs;


public class TeacherDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public ICollection<TeacherCourseDto> TeacherCourses { get; set; } = new List<TeacherCourseDto>();
}
