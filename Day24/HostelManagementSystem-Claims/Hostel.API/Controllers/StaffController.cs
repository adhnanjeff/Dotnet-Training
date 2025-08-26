using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet("me")]       //  Day 24
        [Authorize]
        public IActionResult GetMyClaims()
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            return Ok(new
            {
                userName,
                role
            });
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_staffService.GetAllStaffs());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var staff = _staffService.GetStaffById(id);
            if (staff == null)
                return NotFound();

            return Ok(staff);
        }

        [Authorize(Roles = "Admin")]
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
