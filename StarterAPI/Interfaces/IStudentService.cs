using StarterAPI.Entities;

namespace StarterAPI.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int studentId);

        Task<Student> CreateStudent(Student param, CancellationToken ct);
        Task<Student> UpdateStudent(Student param, CancellationToken ct);
        Task<bool> RemoveStudent(int studentId, CancellationToken ct);
    }
}
