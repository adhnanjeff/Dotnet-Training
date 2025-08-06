using BugTrackerMapper.Application.Mapping;
using BugTrackerMapper.Application.Services;
using BugTrackerMapper.Core.DTOs;
using BugTrackerMapper.Infrastructure.Repositories; 

using AutoMapper;
using Microsoft.Extensions.Logging;

namespace BugTrackerMapper.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting up a logger factory
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            // Configuring AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }, loggerFactory);
            IMapper mapper = config.CreateMapper();

            // Set up repositories and services (should be singleton within app)
            var bugRepo = new BugRepository();
            var bugService = new BugService(bugRepo, mapper);

            var projectRepo = new ProjectRepository();
            var projectService = new ProjectService(projectRepo, mapper);

            while (true)
            {
                Console.WriteLine("\n1. Add Bug");
                Console.WriteLine("2. Add Project");
                Console.WriteLine("3. View all Bugs");
                Console.WriteLine("4. View all Projects");
                Console.WriteLine("5. Update Bug");
                Console.WriteLine("6. Update Project");
                Console.WriteLine("7. Delete Bug");
                Console.WriteLine("8. Delete Project");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // Add Bug
                        Console.Write("Enter Bug Title: ");
                        var bugTitle = Console.ReadLine();
                        Console.Write("Enter Bug Description: ");
                        var bugDescription = Console.ReadLine();
                        Console.Write("Enter Bug Status: ");
                        var bugStatus = Console.ReadLine();
                        Console.Write("Enter Bug Due Date (yyyy-mm-dd): ");
                        var bugDueDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                        var bugDto = new BugRequestDTO
                        {
                            Title = bugTitle,
                            Description = bugDescription,
                            Status = bugStatus,
                            DueDate = bugDueDate
                        };

                        bugService.AddBug(bugDto);
                        Console.WriteLine("Bug added successfully.");
                        break;

                    case "2":
                        // Add Project
                        Console.Write("Enter Project Name: ");
                        var projectName = Console.ReadLine();
                        Console.Write("Enter Project Description: ");
                        var projectDescription = Console.ReadLine();
                        Console.Write("Enter Project Start Date (yyyy-mm-dd): ");
                        var startDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                        var projectDto = new ProjectRequestDTO
                        {
                            Name = projectName,
                            Description = projectDescription,
                            StartDate = startDate
                        };

                        projectService.AddProject(projectDto);
                        Console.WriteLine("Project added successfully.");
                        break;

                    case "3":
                        // View All Bugs
                        bugService.GetAllBugs();
                        break;

                    case "4":
                        // View All Projects
                        projectService.GetAllProjects();
                        break;

                    case "5":
                        // Update Bug
                        Console.Write("Enter Bug Id to update: ");
                        if (int.TryParse(Console.ReadLine(), out int bugUpdId))
                        {
                            var bugToUpdate = bugService.GetBugById(bugUpdId);
                            if (bugToUpdate != null)
                            {
                                Console.Write($"Enter New Title ({bugToUpdate.Title}): ");
                                bugToUpdate.Title = Console.ReadLine();
                                Console.Write($"Enter New Description ({bugToUpdate.Description}): ");
                                bugToUpdate.Description = Console.ReadLine();
                                Console.Write($"Enter New Status ({bugToUpdate.Status}): ");
                                bugToUpdate.Status = Console.ReadLine();
                                Console.Write($"Enter New Due Date ({bugToUpdate.DueDate:yyyy-MM-dd}): ");
                                
                                var dueDateInput = Console.ReadLine();
                                bugToUpdate.DueDate = DateTime.Now;

                                bugService.UpdateBug(bugToUpdate);
                                Console.WriteLine("Bug updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Bug not found.");
                            }
                        }
                        break;

                    case "6":
                        // Update Project
                        Console.Write("Enter Project Id to update: ");
                        if (int.TryParse(Console.ReadLine(), out int projUpdId))
                        {
                            var projectToUpdate = projectService.GetProjectById(projUpdId);
                            if (projectToUpdate != null)
                            {
                                Console.Write($"Enter New Name ({projectToUpdate.Name}): ");
                                projectToUpdate.Name = Console.ReadLine();
                                Console.Write($"Enter New Description ({projectToUpdate.Description}): ");
                                projectToUpdate.Description = Console.ReadLine();
                                Console.Write($"Enter New Start Date ({projectToUpdate.StartDate:yyyy-MM-dd}): ");
                                projectToUpdate.StartDate = DateTime.Now;

                                projectService.UpdateProject(projectToUpdate);
                                Console.WriteLine("Project updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Project not found.");
                            }
                        }
                        break;

                    case "7":
                        // Delete Bug
                        Console.Write("Enter Bug Id to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int bugDelId))
                        {
                            bugService.DeleteBug(bugDelId);
                            Console.WriteLine("Bug deleted (if existed).");
                        }
                        break;

                    case "8":
                        // Delete Project
                        Console.Write("Enter Project Id to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int projDelId))
                        {
                            projectService.DeleteProject(projDelId);
                            Console.WriteLine("Project deleted (if existed).");
                        }
                        break;

                    case "9":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
