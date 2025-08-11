using BugTrack.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BugTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly IBugService _service;
        public BugController(IBugService bugService) {
            _service = bugService;
        }
        [HttpGet] //Get all bugs
        public IActionResult GetAll() => Ok(_service.GetAllBugs());

        [HttpGet("{id}")] //Get bug by id
        public IActionResult GetById(int id)
        {
            var bug = _service.GetBugById(id);
            if (bug == null)
                return NotFound();
            return Ok(bug);
        }

        [HttpGet("project/{projectId}")] //Get bugs by project id
        public IActionResult GetByProjectId(int projectId)
        {
            var bugs = _service.GetBugsByProjectId(projectId);
            if (bugs == null || !bugs.Any())
                return NotFound();
            return Ok(bugs);
        }
    }
}
