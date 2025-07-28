using IssueTracker.Application.Services;
using IssueTracker.Infrastructure.Repositories;
using IssueTracker.Core.Entities;
using IssueTracker.Core.Interfaces;
namespace IssueTracker.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bugRepo = new BugRepository();
            var bugService = new BugService(bugRepo);

            while (true) {
                Console.WriteLine("1. Create a Bug\n" +
                                  "2. Delete a Bug\n" +
                                  "3. Update a Bug\n" +
                                  "4. View all Bugs\n" +
                                  "5. Exit\n");
                Console.WriteLine("Enter your Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter the title of the bug\n");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter the description of the bug\n");
                        string des = Console.ReadLine();
                        bugService.CreateBug(title, des);
                        break;

                    case 2:
                        Console.WriteLine("Enter the Id of the bug to be deleted\n");
                        int bugId = Convert.ToInt32(Console.ReadLine());
                        bugRepo.DeleteBug(bugId);
                        break;

                    case 3:
                        Console.WriteLine("Enter the Id of the bug to be updated\n");
                        int toUpdateBugId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the new title of the bug\n");
                        string newTitle = Console.ReadLine();
                        Console.WriteLine("Enter the new status of the bug (e.g., 'open', 'closed')\n");
                        string newStatus = Console.ReadLine();
                        bugRepo.UpdateBug(toUpdateBugId, newTitle, newStatus);
                        break;

                    case 4: 
                        var bugs = bugRepo.GetAll();
                        if (bugs.Count == 0) { 
                            Console.WriteLine("No bugs found.\n");
                        }
                        else { 
                            Console.WriteLine("Bugs fetched successfully\n");
                            foreach (var bug in bugs) {
                                Console.WriteLine($"ID: {bug.Id}, Title: {bug.Title}, Description: {bug.Description}, Status: {bug.Status}\n");
                            }
                        }
                        break;

                    case 5: 
                        Console.WriteLine("Exiting the application.");
                        return;
                }

            }
        }
    }
}