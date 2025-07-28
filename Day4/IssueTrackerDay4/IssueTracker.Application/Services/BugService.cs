using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IssueTracker.Infrastructure.Repositories;
using IssueTracker.Core.Entities;
using IssueTracker.Core.Interfaces;

namespace IssueTracker.Application.Services
{
    public class BugService {
        private readonly IBugRepository _repo;
        public BugService(IBugRepository repo)
        {
            _repo = repo;
        }

        public void CreateBug(string title, string description)
        {
            var bug = new Bug
            {
                Title = title,
                Description = description,
                Status = "Open"
            };
            _repo.AddBug(bug);
            Console.WriteLine($"Bug created: {bug.Title}");
        }

        public List<Bug> GetAllBugs() { 
            Console.WriteLine("Fetching all bugs...");
            return _repo.GetAll(); 
        }
    }
}
