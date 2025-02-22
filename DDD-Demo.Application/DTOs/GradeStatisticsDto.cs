namespace Core.DTOs;

public class GradeStatisticsDto
{
    public decimal OverallAverageGrade { get; set; }
    public int StudentsEligibleForFrance { get; set; }
    public decimal HighestAverageGrade { get; set; }
    public decimal LowestAverageGrade { get; set; }
    public IDictionary<string, decimal> AverageGradeByCourse { get; set; } = new Dictionary<string, decimal>();
}
