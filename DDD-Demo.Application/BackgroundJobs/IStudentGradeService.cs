namespace Core.Application.BackgroundJobs
{
    public interface IStudentGradeService
    {
        Task RecalculateAllStudentGradeAverages();
    }
}