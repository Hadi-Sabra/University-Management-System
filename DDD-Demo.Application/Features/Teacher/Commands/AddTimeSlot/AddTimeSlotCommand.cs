using MediatR;

namespace Core.Features.Teacher.Commands.AddTimeSlot;

public record AddTimeSlotCommand : IRequest<Unit>
{
    public Guid TeacherId { get; init; }
    public Guid CourseId { get; init; }
    public DateTime StartTime { get; init; }
    public DateTime EndTime { get; init; }
}
