using MediatR;

namespace Core.Features.Courses.Commands.CreateCourse;

public record CreateCourseCommand : IRequest<Guid>
{
    public string Name { get; init; }
    public string Code { get; init; }
    public int MaximumStudents { get; init; }
    public DateTime EnrollmentStartDate { get; init; }
    public DateTime EnrollmentEndDate { get; init; }
}