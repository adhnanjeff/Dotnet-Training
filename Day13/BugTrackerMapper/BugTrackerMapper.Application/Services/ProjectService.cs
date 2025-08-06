using AutoMapper;
using BugTrackerMapper.Core.DTOs;
using BugTrackerMapper.Core.Entities;
using BugTrackerMapper.Core.Interfaces;


namespace BugTrackerMapper.Application.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository? _projectRepository; 
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public void AddProject(ProjectRequestDTO projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            _projectRepository.Add(project);
        }
        public void GetAllProjects()
        {
            var projects = _projectRepository.GetAll();
            var projectDtos = _mapper.Map<List<ProjectResponseDTO>>(projects);
            foreach (var project in projectDtos)
            {
                Console.WriteLine($"Id: {project.Id}, Name: {project.Name}, Description: {project.Description}, StartDate: {project.StartDate}");
            }
        }
        public ProjectRequestDTO? GetProjectById(int id)
        {
            var project = _projectRepository.GetById(id);
            return project != null ? _mapper.Map<ProjectRequestDTO>(project) : null;
        }
        public void UpdateProject(ProjectRequestDTO projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            _projectRepository.Update(project);
        }
        public void DeleteProject(int id)
        {
            _projectRepository.Delete(id);
        }
    }
}
