using Hostel.Application.Services;
using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
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
        public IActionResult Create([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentDto = new StudentRequestDTO
            {
                Name = student.Name,
                RoomId = student.RoomId
            };

            _studentService.CreateStudent(studentDto);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }
    }
}
