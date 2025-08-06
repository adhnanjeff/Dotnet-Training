using System;
using AutoMapper;
using EmployeeTrackerMapper.Application.Mapping;
using EmployeeTrackerMapper.Application.Services;
using EmployeeTrackerMapper.Core.DTOs;
using EmployeeTrackerMapper.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace EmployeeTrackerMapper.ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }, loggerFactory);
            IMapper mapper = config.CreateMapper();

            var employeeRepository = new EmployeeRepository();
            var departmentRepository = new DepartmentRepository();
            var employeeService = new EmployeeService(employeeRepository, mapper);
            var departmentService = new DepartmentService(departmentRepository, mapper);

            while (true)
            {
                Console.WriteLine("\n1. Add Department");
                Console.WriteLine("2. Add Employee");
                Console.WriteLine("3. View all Departments");
                Console.WriteLine("4. View all Employees");
                Console.WriteLine("5. Update Department");
                Console.WriteLine("6. Update Employee");
                Console.WriteLine("7. Delete Department");
                Console.WriteLine("8. Delete Employee");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Enter Department Name: ");
                        string deptName = Console.ReadLine() ?? string.Empty;

                        var departmentDto = new DepartmentRequestDTO
                        {
                            Name = deptName
                        };

                        departmentService.AddDepartment(departmentDto);
                        Console.WriteLine("Department added successfully.");
                        break;

                    case "2":
                        Console.Write("Enter Employee Name: ");
                        string empName = Console.ReadLine() ?? string.Empty;

                        Console.Write("Enter Employee Role: ");
                        string empRole = Console.ReadLine() ?? string.Empty;

                        decimal empSalary;
                        while (true)
                        {
                            Console.Write("Enter Employee Salary: ");
                            if (decimal.TryParse(Console.ReadLine(), out empSalary))
                                break;
                            Console.WriteLine("Invalid salary. Please enter a valid number.");
                        }

                        int deptId;
                        while (true)
                        {
                            Console.Write("Enter Department Id: ");
                            if (int.TryParse(Console.ReadLine(), out deptId))
                                break;
                            Console.WriteLine("Invalid Department Id. Please enter a valid integer.");
                        }

                        var employeeDto = new EmployeeRequestDTO
                        {
                            Name = empName,
                            Role = empRole,
                            Salary = (int)empSalary,
                            DepartmentId = deptId
                        };

                        employeeService.AddEmployee(employeeDto);
                        Console.WriteLine("Employee added successfully.");
                        break;

                    case "3":
                        var departments = departmentService.GetAllDepartments();
                        Console.WriteLine("\nDepartments:");
                        foreach (var d in departments)
                        {
                            Console.WriteLine($"Id: {d.Id}, Name: {d.Name}");
                        }
                        break;

                    case "4":
                        var employees = employeeService.GetAllEmployees();
                        Console.WriteLine("\nEmployees:");
                        foreach (var e in employees)
                        {
                            Console.WriteLine($"Id: {e.Id}, Name: {e.Name}, Role: {e.Role}, Department Id: {e.DepartmentId}");
                        }
                        break;

                    // Replace this block in case "5" (Update Department):

                    case "5":
                        Console.Write("Enter Department Id to update: ");
                        if (int.TryParse(Console.ReadLine(), out int deptUpdateId))
                        {
                            var deptToUpdateResp = departmentService.GetDepartmentById(deptUpdateId);
                            if (deptToUpdateResp == null)
                            {
                                Console.WriteLine("Department not found.");
                                break;
                            }

                            // Map DepartmentResponseDTO to DepartmentRequestDTO
                            var deptToUpdate = new DepartmentRequestDTO
                            {
                                Name = deptToUpdateResp.Name
                            };

                            Console.Write($"Enter new Name ({deptToUpdate.Name}): ");
                            string newDeptName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newDeptName))
                                deptToUpdate.Name = newDeptName;

                            departmentService.UpdateDepartment(deptToUpdate);
                            Console.WriteLine("Department updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Department Id.");
                        }
                        break;

                    case "6":
                        Console.Write("Enter Employee Id to update: ");
                        if (int.TryParse(Console.ReadLine(), out int empUpdateId))
                        {
                            var empToUpdateResp = employeeService.GetEmployeeById(empUpdateId);
                            if (empToUpdateResp == null)
                            {
                                Console.WriteLine("Employee not found.");
                                break;
                            }
                            var empToUpdate = mapper.Map<EmployeeRequestDTO>(empToUpdateResp);
                            Console.Write($"Enter new Name ({empToUpdate.Name}): ");
                            string newEmpName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newEmpName))
                                empToUpdate.Name = newEmpName;

                            Console.Write($"Enter new Role ({empToUpdate.Role}): ");
                            string newEmpRole = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newEmpRole))
                                empToUpdate.Role = newEmpRole;

                            while (true)
                            {
                                Console.Write($"Enter new Department Id ({empToUpdate.DepartmentId}): ");
                                string newDeptIdInput = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(newDeptIdInput))
                                    break;
                                if (int.TryParse(newDeptIdInput, out int newDeptId))
                                {
                                    empToUpdate.DepartmentId = newDeptId;
                                    break;
                                }
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                            }

                            employeeService.UpdateEmployee(empToUpdate);
                            Console.WriteLine("Employee updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Employee Id.");
                        }
                        break;

                    case "7":
                        Console.Write("Enter Department Id to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deptDelId))
                        {
                            departmentService.DeleteDepartment(deptDelId);
                            Console.WriteLine("Deleted department if it existed.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Department Id.");
                        }
                        break;

                    case "8":
                        Console.Write("Enter Employee Id to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int empDelId))
                        {
                            employeeService.DeleteEmployee(empDelId);
                            Console.WriteLine("Deleted employee if it existed.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Employee Id.");
                        }
                        break;

                    case "9":
                        return;

                    default:
                        Console.WriteLine("Invalid option, please choose again.");
                        break;
                }
            }
        }
    }
}
