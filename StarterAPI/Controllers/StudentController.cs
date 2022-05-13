using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarterAPI.Interfaces;
using StarterAPI.Entities;
using StarterAPI.Presistence;

namespace StarterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IApplicationDbContext _context;

        public StudentController(IApplicationDbContext context)
        {
                _context = context;
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        [HttpGet("(profile)")]
        public async Task<IActionResult> GetStudent(int studentId)
        {
            var student = await _context.Students.FindAsync(new object[] { studentId });
            if (student == null)
            {
                return BadRequest(new { error = "Student not found" });
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student param, CancellationToken ct = default)
        {
            try
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

                return Ok(newStudent);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public IActionResult DeleteStudent()
        {
            throw new NotImplementedException();
        }
    }
}
