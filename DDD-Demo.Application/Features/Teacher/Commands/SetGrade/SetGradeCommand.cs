using MediatR;

namespace Core.Features.Teacher.Commands.SetGrade;


public record SetGradeCommand : IRequest<Unit>
{
    public Guid TeacherId { get; init; }
    public Guid StudentId { get; init; }
    public Guid CourseId { get; init; }
    public decimal Grade { get; init; }
}
