using MediatR;

namespace Core.Features.Student.Commands.EnrollInCourse;

public record EnrollInCourseCommand : IRequest<Unit>
{
    public Guid StudentId { get; init; }
    public Guid CourseId { get; init; }
    public DateTime EnrollmentDate { get; init; } = DateTime.UtcNow;
}