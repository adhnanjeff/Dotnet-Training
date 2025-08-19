using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentRequestDTO student)
        {
            _studentService.CreateStudent(student);

            return StatusCode(StatusCodes.Status201Created,
                new { message = "Student created successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StudentRequestDTO student)
        {
            var existing = _studentService.GetStudentById(id);
            if (existing == null)
                return NotFound();

            _studentService.UpdateStudent(id, student);

            return Ok(new { message = "Student updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _studentService.GetStudentById(id);
            if (existing == null)
                return NotFound();

            _studentService.DeleteStudent(id);

            return Ok(new { message = "Student deleted successfully" });
        }
    }
}
