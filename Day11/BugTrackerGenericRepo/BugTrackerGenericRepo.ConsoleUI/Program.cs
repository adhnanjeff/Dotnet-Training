using BugTrackerGenericRepo.Application.Services;
using BugTrackerGenericRepo.Core.Entities;
using BugTrackerGenericRepo.Core.Interfaces;
using BugTrackerGenericRepo.Infrastructure.Repositories;

namespace BugTrackerGenericRepo.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IBugRepository bugRepository = new BugRepository();
            BugService bugService = new BugService(bugRepository);

            Bug newBug = new Bug
            {
                Id = 1,
                Title = "Sample Bug",
                Description = "This is a sample bug description.",
                Status = "Open",
                CreatedAt = DateTime.Now,
                AssignedTo = new User
                {
                    Id = 1,
                    Username = "Sivadarsini",
                    Email = "abcd@gmail.com",
                    Role = "Developer",
                }, 
                Priority = "Medium",
                Project = new Project
                {
                    Id = 1,
                    Name = "Sample Project",
                    StartDate = DateTime.Now,
                }
            };

            Bug newBug2 = new Bug
            {
                Id = 2,
                Title = "Sample Bug2",
                Description = "This is a sample bug2 description.",
                Status = "Open",
                CreatedAt = DateTime.Now,
                AssignedTo = new User
                {
                    Id = 1,
                    Username = "Sivadarsini",
                    Email = "abcd@gmail.com",
                    Role = "Developer",
                },
                Priority = "High",
                Project = new Project
                {
                    Id = 2,
                    Name = "Sample Project",
                    StartDate = DateTime.Now,
                }
            };
            bugService.AddBug(newBug);
            bugService.AddBug(newBug2);
            Console.WriteLine("Bugs added successfully!");

            List<Bug> bugs = bugService.GetAllBugs();
            Console.WriteLine("Current Bugs:");
            foreach (var bug in bugs)
            {
                Console.WriteLine($"ID: {bug.Id}, Title: {bug.Title}, Status: {bug.Status}, Assigned To: {bug.AssignedTo}, Priority: {bug.Priority}");
            }

            if (bugs.Count > 0)
            {
                Console.WriteLine($"Enter the Id of the bug to be updated: (Out of {bugs.Count})");
                int bugIdToUpdate = int.Parse(Console.ReadLine());
                Bug bugToUpdate = bugService.GetBugById(bugIdToUpdate);
                bugToUpdate.Status = "In Progress";
                bugService.UpdateBug(bugToUpdate);
                Console.WriteLine($"Bug ID {bugToUpdate.Id} updated successfully!");
            }

            if (bugs.Count > 0)
            {
                Console.WriteLine($"Enter the Id of the bug to be deleted: (Out of {bugs.Count})");
                int bugIdToDelete = int.Parse(Console.ReadLine());
                bugService.DeleteBug(bugIdToDelete);
                Console.WriteLine($"Bug ID {bugIdToDelete} deleted successfully!");
            }

            bugs = bugService.GetAllBugs();
            Console.WriteLine("Remaining Bugs:");
            foreach (var bug in bugs)
            {
                Console.WriteLine($"ID: {bug.Id}, Title: {bug.Title}, Status: {bug.Status}, Assigned To: {bug.AssignedTo}, Priority: {bug.Priority}");
            }
        }
    }
}