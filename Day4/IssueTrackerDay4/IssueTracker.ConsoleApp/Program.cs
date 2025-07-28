
using System;

using IssueTracker.Application.Services;
using IssueTracker.Infrastructure.Repositories;
using IssueTracker.Core.Entities;
using IssueTracker.Core.Interfaces;
namespace IssueTracker.ConsoleApp
{
    public class Program {
        public static void Main(string[] args) {
            var bugRepository = new BugRepository();
            var bugService = new BugService(bugRepository);

            bugService.CreateBug("Login Bug", "User cannot login.");
            bugService.CreateBug("UI Bug", "Button not aligned properly.");
            Console.WriteLine("Bugs created successfully!");

            var bugs = bugService.GetAllBugs();
            if(bugs.Count == 0) {
                Console.WriteLine("No bugs found.");
                return;
            }
            Console.WriteLine("Bug fetched successfully");
            foreach (var bug in bugs) {
                Console.WriteLine($"ID: {bug.Id}, Title: {bug.Title}, Description: {bug.Description}, Status: {bug.Status}");
            }
            
        }
    }
}