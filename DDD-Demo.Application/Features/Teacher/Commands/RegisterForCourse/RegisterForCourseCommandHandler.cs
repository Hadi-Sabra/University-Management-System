using Common;
using Core.Domain.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Teacher.Commands.RegisterCourse;


public class RegisterForCourseCommandHandler : IRequestHandler<RegisterForCourseCommand, Unit>
{
    private readonly IApplicationDbContext _dbContext;
    
    public RegisterForCourseCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Unit> Handle(RegisterForCourseCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _dbContext.Teachers
            .Include(t => t.TeacherCourses)
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
        
        teacher.RegisterForCourse(course);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
