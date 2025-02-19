using MediatR;

namespace Core.Features.Teacher.Commands.RegisterCourse;

public record RegisterForCourseCommand : IRequest<Unit>
{
    public Guid TeacherId { get; init; }
    public Guid CourseId { get; init; }
}