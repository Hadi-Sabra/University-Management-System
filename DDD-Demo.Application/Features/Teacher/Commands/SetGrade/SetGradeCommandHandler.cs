using MediatR;

namespace Core.Features.Teacher.Commands.SetGrade;

public class SetGradeCommandHandler : IRequestHandler<SetGradeCommand, Unit>
{
    private readonly IApplicationDbContext _dbContext;
    
    public SetGradeCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Unit> Handle(SetGradeCommand request, CancellationToken cancellationToken)
    {
        // Verify the teacher is assigned to the course
        var teacherCourse = await _dbContext.TeacherCourses
            .AnyAsync(tc => tc.TeacherId == request.TeacherId && tc.CourseId == request.CourseId, 
                cancellationToken);
        
        if (!teacherCourse)
        {
            throw new InvalidOperationException("Teacher is not assigned to this course");
        }
        
        // Get the enrollment
        var enrollment = await _dbContext.Enrollments
            .Include(e => e.Student)
            .FirstOrDefaultAsync(e => e.StudentId == request.StudentId && e.CourseId == request.CourseId,
                cancellationToken);
        
        if (enrollment == null)
        {
            throw new NotFoundException("Enrollment not found for the specified student and course");
        }
        
        // Set the grade
        enrollment.SetGrade(request.Grade);
        
        // Update student's grade average
        enrollment.Student.UpdateGradeAverage();
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}