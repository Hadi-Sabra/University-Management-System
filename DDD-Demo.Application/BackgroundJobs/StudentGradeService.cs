using Core.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Core.Application.BackgroundJobs
{
    public class StudentGradeService : IStudentGradeService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<StudentGradeService> _logger;

        public StudentGradeService(IStudentRepository studentRepository, ILogger<StudentGradeService> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        public async Task RecalculateAllStudentGradeAverages()
        {
            _logger.LogInformation("Starting hourly recalculation of all student grade averages");
            
            try
            {
                // Get all students with grades
                var students = await _studentRepository.GetAllWithGradesAsync();
                
                foreach (var student in students)
                {
                    // This method recalculates GradeAverage and updates CanApplyToFrance
                    student.UpdateGradeAverage();
                    
                    // Save changes
                    await _studentRepository.UpdateAsync(student);
                }
                
                _logger.LogInformation($"Successfully recalculated grade averages for {students.Count} students");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while recalculating student grade averages");
                throw;
            }
        }
    }
}