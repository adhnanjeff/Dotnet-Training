using EventEase.Core.DTOs;
using EventEase.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _regService;

        public RegistrationController(IRegistrationService regService)
        {
            _regService = regService;
        }

        // GET: api/Registration/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RegisterationResponseDTO>>> GetAllRegistrations()
        {
            var result = await _regService.GetAllRegistrationsAsync();
            return Ok(result);
        }

        // GET: api/Registration/{registrationId}
        [HttpGet("{registrationId:int}")]
        public async Task<ActionResult<RegisterationResponseDTO>> GetRegistrationById(int registrationId)
        {
            var registration = await _regService.GetRegistrationByIdAsync(registrationId);
            if (registration == null)
            {
                return NotFound(new { Message = $"Registration with ID {registrationId} not found." });
            }
            return Ok(registration);
        }

        // POST: api/Registration
        [HttpPost]
        public async Task<ActionResult<RegisterationResponseDTO>> AddRegistration(RegistrationRequestDTO registration)
        {
            var createdRegistration = await _regService.AddRegistrationAsync(registration);

            return CreatedAtAction(
                nameof(GetRegistrationById),
                new { registrationId = createdRegistration.Id },
                createdRegistration
            );
        }


        // DELETE: api/Registration/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegistration(int id)
        {
            await _regService.DeleteRegistration(id);
            return NoContent();
        }
    }
}
