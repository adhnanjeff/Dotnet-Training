using Hostel.Core.Interfaces;
using Hostel.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IStudentService _studentService;
        private readonly IStaffService _staffService;

        public RoomController(IRoomService roomService, IStudentService studentService, IStaffService staffService)
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

        [HttpPost]
        public IActionResult Create([FromBody] RoomRequestDTO roomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _roomService.CreateRoom(roomDto);
            return Created(string.Empty, null);
        }
    }
}
