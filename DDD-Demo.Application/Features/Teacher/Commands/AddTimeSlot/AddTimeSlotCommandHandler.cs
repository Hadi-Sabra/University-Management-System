using MediatR;

namespace Core.Features.Teacher.Commands.AddTimeSlot;

public class AddTimeSlotCommandHandler : IRequestHandler<AddTimeSlotCommand, Unit>
{
    private readonly IApplicationDbContext _dbContext;
    
    public AddTimeSlotCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Unit> Handle(AddTimeSlotCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _dbContext.Teachers
            .Include(t => t.TeacherCourses)
            .ThenInclude(tc => tc.TimeSlots)
            .FirstOrDefaultAsync(t => t.Id == request.TeacherId, cancellationToken);
        
        if (teacher == null)
        {
            throw new NotFoundException(nameof(Teacher), request.TeacherId);
        }
        
        var course = await _dbContext.Courses
            .FirstOrDefaultAsync(c => c.Id == request.CourseId, cancellationToken);
        
        if (course == null)
        {
            throw new NotFoundException(nameof(Course), request.CourseId);
        }
        
        teacher.AddTimeSlot(course, request.StartTime, request.EndTime);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}