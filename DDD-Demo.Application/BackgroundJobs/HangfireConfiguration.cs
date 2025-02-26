using Core.Application.BackgroundJobs;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.BackgroundJobs
{
    public static class HangfireConfiguration
    {
        public static IServiceCollection AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register Hangfire services with PostgreSQL storage
            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(configuration.GetConnectionString("DefaultConnection")));

            // Add Hangfire server
            services.AddHangfireServer();

            // Register background job services
            services.AddScoped<IStudentGradeService, StudentGradeService>();
            services.AddScoped<IEnrollmentNotificationService, EnrollmentNotificationService>();

            return services;
        }

        public static IApplicationBuilder UseHangfireServices(this IApplicationBuilder app)
        {
            // Configure Hangfire dashboard
            app.UseHangfireDashboard();

            // Schedule recurring jobs
            RecurringJob.AddOrUpdate<IStudentGradeService>(
                "RecalculateStudentGradeAverages",
                service => service.RecalculateAllStudentGradeAverages(),
                Cron.Hourly);

            RecurringJob.AddOrUpdate<IEnrollmentNotificationService>(
                "SendEnrollmentDeadlineNotifications",
                service => service.SendEnrollmentDeadlineNotifications(),
                Cron.Daily);

            return app;
        }
    }
}