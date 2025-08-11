using Hostel.Application.Services;
using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly StaffService _staffService;

        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_staffService.GetAllStaff());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var staff = _staffService.GetStaffById(id);
            if (staff == null)
                return NotFound();

            return Ok(staff);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Staff staff)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var staffDto = new StaffRequestDTO
            {
                Name = staff.Name,
                RoomIds = staff.RoomIds
            };

            _staffService.CreateStaff(staffDto);
            return CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff);
        }
    }
}
