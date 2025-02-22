namespace Core.DTOs.Requests;

public class AddTimeSlotRequest
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}