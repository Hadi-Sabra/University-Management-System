namespace Core.Application.BackgroundJobs
{
    public interface IEnrollmentNotificationService
    {
        Task SendEnrollmentDeadlineNotifications();
    }
}