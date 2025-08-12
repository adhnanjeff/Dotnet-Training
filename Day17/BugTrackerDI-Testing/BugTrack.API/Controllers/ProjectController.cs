using BugTrack.Core.DTOs;
using BugTrack.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BugTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService proService)
        {
            _service = proService;
        }

        // GET api/project
        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllProjects());

        // GET api/project/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pro = _service.GetProjectById(id);
            if (pro == null)
                return NotFound();
            return Ok(pro);
        }

        // POST api/project
        [HttpPost]
        public IActionResult Create(ProjectRequestDTO request)
        {
            var createdProject = _service.CreateProject(request);
            return CreatedAtAction(nameof(GetById), new { id = createdProject.Id }, createdProject);
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody]ProjectRequestDTO request)
        {
            _service.UpdateProject(id, request);
            return StatusCode(200, new {Message = "Project Updated Successfully"});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.DeleteProject(id);
            return Ok();
        }
    }
}
