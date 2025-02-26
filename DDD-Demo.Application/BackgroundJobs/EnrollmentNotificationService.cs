using Core.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Core.Application.Services;

namespace Core.Application.BackgroundJobs
{
    public class EnrollmentNotificationService : IEnrollmentNotificationService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly INotificationService _notificationService;
        private readonly ILogger<EnrollmentNotificationService> _logger;

        public EnrollmentNotificationService(
            ICourseRepository courseRepository,
            INotificationService notificationService,
            ILogger<EnrollmentNotificationService> logger)
        {
            _courseRepository = courseRepository;
            _notificationService = notificationService;
            _logger = logger;
        }

        public async Task SendEnrollmentDeadlineNotifications()
        {
            _logger.LogInformation("Starting daily enrollment deadline notification check");
            
            try
            {
                var currentDate = DateTime.UtcNow;
                
                // Get courses with enrollment deadlines approaching (3 days from now)
                var approachingDeadlineCourses = await _courseRepository
                    .GetCoursesWithEnrollmentDeadlineApproaching(currentDate.AddDays(3));
                
                foreach (var course in approachingDeadlineCourses)
                {
                    // Get eligible students who haven't enrolled yet
                    var eligibleStudents = await _courseRepository.GetEligibleUnenrolledStudents(course.Id);
                    
                    foreach (var student in eligibleStudents)
                    {
                        await _notificationService.SendEnrollmentDeadlineReminder(
                            student.Email,
                            course.Name,
                            course.EnrollmentEndDate);
                    }
                }
                
                _logger.LogInformation($"Sent enrollment deadline notifications for {approachingDeadlineCourses.Count} courses");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while sending enrollment deadline notifications");
                throw;
            }
        }
    }
}