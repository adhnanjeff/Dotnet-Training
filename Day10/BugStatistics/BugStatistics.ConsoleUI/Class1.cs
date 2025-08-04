using BugStatistics.Application.Services;
using BugStatistics.Core.Entities;
using BugStatistics.Core.Interfaces;
using BugStatistics.Infrastructure.Repositories;

namespace BugStatistics.ConsoleUI;

public class Class1
{
    public static void Main(string[] args)
    {
        Console.WriteLine("This is Bug Statistics!");
        IBugRepository bugRepository = new BugRepository(
            new Project { Id = 1, Name = "Project A" },
            new User { Id = 1, Username = "user1" }
        );
        BugService bugService = new BugService(bugRepository);
        while (true)
        {
            Console.WriteLine("--------------");
            Console.WriteLine("1. Get All Bugs");
            Console.WriteLine("2. Filter by Status/Priority/Project");
            Console.WriteLine("3. Sort by created date");
            Console.WriteLine("4. Show grouped stats");
            Console.WriteLine("5. Exit");
            Console.WriteLine("--------------");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    bugService.GetAllBugs();
                    break;
                case "2":
                    Console.Write("Enter Status (or leave empty): ");
                    string? status = Console.ReadLine();
                    Console.Write("Enter Priority (or leave empty): ");
                    string? priority = Console.ReadLine();
                    Console.WriteLine("Enter Project Name (or leave empty): ");
                    string? projectName = Console.ReadLine();
                    bugService.FilterBugs(status, priority, projectName);
                    break;
                case "3":
                    bugService.sortBugsByCreatedDate();
                    break;
                case "4":
                    Console.WriteLine("Grouped stats feature is not yet implemented.");
                    bugService.groupedStats();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
