namespace BugStatisticsDashboard.ConsoleUI;
using System;
using BugStatisticsDashboard.Application.Services;
using BugStatisticsDashboard.Infrastructure.Repositories;
using BugStatisticsDashboard.Core.Interfaces;
using BugStatisticsDashboard.Core.Entity;

public class Class1
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Bug Statistics Dashboard!");
        IBugRepository bugRepository = new BugRepository();
        BugStatisticsService bugStatisticsService = new BugStatisticsService(bugRepository);

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Show Bug Count by Status");
            Console.WriteLine("2. Show Bug Count by Project and Priority");
            Console.WriteLine("3. Show Daily Bug Report");
            Console.WriteLine("4. Show Top Creators");
            Console.WriteLine("5. Exit");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    bugStatisticsService.showBugCountByStatus();
                    break;
                case "2":
                    bugStatisticsService.showBugCountByProjectAndPriority();
                    break;
                case "3":
                    bugStatisticsService.showDailyBugReport();
                    break;
                case "4":
                    bugStatisticsService.showTopCreators();
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
