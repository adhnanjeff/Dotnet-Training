using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_staffService.GetAllStaffs());
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
        public IActionResult Create([FromBody] StaffRequestDTO staffRequestDTO)
        {
            

            var staffDto = new Staff
            {
                Name = staffRequestDTO.Name,
            };

            _staffService.CreateStaff(staffRequestDTO);
            return CreatedAtAction(nameof(GetById), new { id = staffDto.Id }, staffDto);
        }
    }
}
