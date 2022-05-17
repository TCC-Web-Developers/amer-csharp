using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarterAPI.Interfaces;
using StarterAPI.Entities;
using StarterAPI.Presistence;

namespace StarterAPI.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
                _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentService.Get();
            return Ok(new {data = students});
        }

        [HttpGet("(profile)")]
        public async Task<IActionResult> GetStudent(int studentId)
        {
            var student = await _studentService.Get(studentId);
            return Ok(new {data = student});
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student request, CancellationToken ct = default)
        {
            var newStudent = await _studentService.CreateStudent(request, ct);
            return Ok(new { data = newStudent });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int studentId, CancellationToken ct = default)
        {
            var isDeleted = await _studentService.DeleteStudent(studentId, ct);
            return Ok(new { data = isDeleted });
        }
    }
}
