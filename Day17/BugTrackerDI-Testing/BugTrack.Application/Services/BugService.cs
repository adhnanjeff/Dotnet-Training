using BugTrack.Core.DTOs;
using BugTrack.Core.Entities;
using BugTrack.Core.Interfaces;
using BugTrack.Infrastructure.Data;

namespace BugTrack.Application.Services
{
    public class BugService : IBugService
    {
        private readonly IBugRepository _context;
        public BugService(IBugRepository context)
        {
            _context = context;
        }
        public void AddBug(BugRequestDTO bugRequest)
        {
            var bug = new Bug
            {
                Title = bugRequest.Title,
                Description = bugRequest.Description,
                ProjectId = bugRequest.ProjectId,
                Status = bugRequest.Status,
                CreatedAt = DateTime.UtcNow
            };
            _context.Add(bug);
        }
        public void UpdateBug(int id, BugRequestDTO bugRequest)
        {
            // Implementation for updating a bug
            var bug = _context.GetById(id);
            
            if (bug == null)
                throw new KeyNotFoundException("Bug not found");
            bug.Title = bugRequest.Title;
            bug.Description = bugRequest.Description;
            bug.ProjectId = bugRequest.ProjectId;
            bug.Status = bugRequest.Status;
            _context.Update(bug);
        }
        public void DeleteBug(int id)
        {
            var bugRequest = _context.GetById(id);
            if (bugRequest == null)
                throw new KeyNotFoundException("Bug not found");
            _context.Delete(id);
        }
        public BugRequestDTO? GetBugById(int id)
        {
            var bug = _context.GetById(id);
            if (bug == null)
                return null;
            return new BugRequestDTO
            {
                Title = bug.Title,
                Description = bug.Description,
                ProjectId = bug.ProjectId,
                Status = bug.Status
            };
        }
        public List<BugResponseDTO> GetAllBugs()
        {
            var bugs = _context.GetAll();
            if (bugs == null) return null;
            return bugs.Select(b => new BugResponseDTO
            {
                Title = b.Title,
                Description = b.Description,
                CreatedAt = DateTime.Now,
                Status = b.Status,
                ProjectId = b.ProjectName.Id,
                Id = b.Id,
                ProjectName = b.ProjectName
            }).ToList();
        }

        public List<BugResponseDTO> GetBugsByProjectId(int projectId)
        {
            var bugs = _context.GetAll()
                .Where(b => b.ProjectId == projectId)
                .Select(b => new BugResponseDTO
                {   
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    CreatedAt = b.CreatedAt,
                    Status = b.Status,
                    ProjectId = b.ProjectName.Id,
                    ProjectName = b.ProjectName 
                })
                .ToList();

            return bugs;
        }
    }
}
