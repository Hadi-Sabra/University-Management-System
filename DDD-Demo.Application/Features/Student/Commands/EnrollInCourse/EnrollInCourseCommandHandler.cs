using Common;
using Core.Domain.Entities;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Student.Commands.EnrollInCourse;


public class EnrollInCourseCommandHandler : IRequestHandler<EnrollInCourseCommand, Unit>
{
    private readonly IApplicationDbContext _dbContext;
    
    public EnrollInCourseCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Unit> Handle(EnrollInCourseCommand request, CancellationToken cancellationToken)
    {
        var student = await _dbContext.Students
            .Include(s => s.Enrollments)
            .FirstOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);
        
        if (student == null)
        {
            throw new NotFoundException(nameof(Student), request.StudentId);
        }
        
        var course = await _dbContext.Courses
            .FirstOrDefaultAsync(c => c.Id == request.CourseId, cancellationToken);
        
        if (course == null)
        {
            throw new NotFoundException(nameof(Course), request.CourseId);
        }
        
        student.EnrollInCourse(course, request.EnrollmentDate);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}