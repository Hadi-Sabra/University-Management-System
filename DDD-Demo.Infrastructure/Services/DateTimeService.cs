using Core.Application.Common.Interfaces;

namespace ProjectName.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
    public DateTime UtcNow { get; }
}