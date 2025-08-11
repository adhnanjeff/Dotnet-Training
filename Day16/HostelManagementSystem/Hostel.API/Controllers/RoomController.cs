using Hostel.Application.Services;
using Hostel.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;
        private readonly StudentService _studentService;
        private readonly StaffService _staffService;

        public RoomController(RoomService roomService, StudentService studentService, StaffService staffService)
        {
            _roomService = roomService;
            _studentService = studentService;
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_roomService.GetAllRooms());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var room = _roomService.GetRoomById(id);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        // Replace the Create method with the following:

        [HttpPost]
        public IActionResult Create([FromBody] RoomRequestDTO roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _roomService.CreateRoom(roomDto);
            return Created(string.Empty, null);
        }

        [HttpGet("{id}/details")]
        public IActionResult GetRoomDetails(int id)
        {
            var room = _roomService.GetRoomById(id);
            if (room == null)
                return NotFound("Room not found");

            var students = room.StudentIds
                .Select(sid => _studentService.GetStudentById(sid))
                .Where(s => s != null)
                .ToList();

            var staff = _staffService.GetAllStaff()
                .Where(st => st.RoomIds.Contains(id))
                .ToList();

            return Ok(new
            {
                Room = room,
                Students = students,
                Staff = staff
            });
        }
    }
}
