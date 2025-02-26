using Core.Domain.Entities;

namespace Core.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllWithGradesAsync();
        Task UpdateAsync(Student student);
    }
}