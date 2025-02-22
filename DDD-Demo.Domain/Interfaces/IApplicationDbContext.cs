using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Admin> Admins { get; }
        DbSet<Teacher> Teachers { get; }
        DbSet<Student> Students { get; }
        DbSet<Course> Courses { get; }
        DbSet<TeacherCourse> TeacherCourses { get; }
        DbSet<TimeSlot> TimeSlots { get; }
        DbSet<Enrollment> Enrollments { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
