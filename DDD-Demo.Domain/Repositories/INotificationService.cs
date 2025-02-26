namespace Core.Application.Services
{
    public interface INotificationService
    {
        Task SendEnrollmentDeadlineReminder(string studentEmail, string courseTitle, DateTime enrollmentEndDate);
    }
}