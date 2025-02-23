using Core.Domain.Entities;
using Core.Interfaces;
using MediatR;

namespace Core.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;
    
    public CreateCourseCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course(
            request.Name,
            request.Code,
            request.MaximumStudents,
            request.EnrollmentStartDate,
            request.EnrollmentEndDate);
        
        await _dbContext.Courses.AddAsync(course, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return course.Id;
    }
}