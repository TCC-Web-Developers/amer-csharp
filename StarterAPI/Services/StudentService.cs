using StarterAPI.Entities;
using StarterAPI.Interfaces;

namespace StarterAPI.Services
{
    public class StudentService : IStudentService
    {
        IApplicationDbContext _context;

        public StudentService(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public async Task<Student> GetStudent(int studentId)
        {
            var student = await _context.Students.FindAsync(new object[] { studentId });
            return student;
        }

        public async Task<Student> CreateStudent(Student param, CancellationToken ct)
        {
            var newStudent = new Student
            {
                FirstName = param.FirstName,
                LastName = param.LastName,
                EmailAddress = param.EmailAddress,
                BirthDate = param.BirthDate,
                DateEnrolled = param.DateEnrolled,
            };
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync(ct);
            string generatedStudentNo = Convert.ToDateTime(param.DateEnrolled).ToString("yyyyMM") + "-" + newStudent.StudentId;
            newStudent.StudentNo = generatedStudentNo;
            await _context.SaveChangesAsync(ct);
            return newStudent;
        }

        

        

        public Task<bool> RemoveStudent(int studentId, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Student param, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Student>> IStudentService.GetStudents()
        {
            throw new NotImplementedException();
        }
    }
}
