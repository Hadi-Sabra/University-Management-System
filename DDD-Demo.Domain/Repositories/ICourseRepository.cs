using Core.Domain.Entities;

namespace Core.Domain.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCoursesWithEnrollmentDeadlineApproaching(DateTime deadline);
        
        Task<List<Student>> GetEligibleUnenrolledStudents(Guid courseId);
    }
}