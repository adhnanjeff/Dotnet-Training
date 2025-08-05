using EmployeeTrackerGenericRepo.Application.Services;
using EmployeeTrackerGenericRepo.Core.Entities;
using EmployeeTrackerGenericRepo.Core.Interfaces;

using EmployeeTrackerGenericRepo.Infrastructure.Repositories;

namespace EmployeeTrackerGenericRepo.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            IDepartmentRepository departmentRepository = new DepartmentRepository();
            EmployeeService employeeService = new EmployeeService(employeeRepository);
            DepartmentService departmentService = new DepartmentService(departmentRepository);

            var department = new Department { Id = 1, Name = "HR" };
            var department2 = new Department { Id = 2, Name = "IT" };
            departmentService.AddDepartment(department);
            departmentService.AddDepartment(department2);

            var employee = new Employee { Id = 1, EmpName = "Ahalya", Department = department };
            var employee2 = new Employee { Id = 2, EmpName = "Amrith", Department = department2 };
            employeeService.AddEmployee(employee);
            employeeService.AddEmployee(employee2);

            Console.WriteLine("Employee and Department added successfully.");
            Console.WriteLine("-------------------------------------------");

            var employees = employeeService.GetAllEmployees();
            Console.WriteLine("Employees:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.EmpName}, Department: {emp.Department.Name}");
            }
            Console.WriteLine("-------------------------------------------");

            var departments = departmentService.GetAllDepartments();
            Console.WriteLine("Departments:");
            foreach (var dept in departments)
            {
                Console.WriteLine($"ID: {dept.Id}, Name: {dept.Name}");
            }
            Console.WriteLine("-------------------------------------------");

            employee.EmpName = "Thejashvini";
            employeeService.UpdateEmployee(employee);
            Console.WriteLine("Employee updated successfully.");

            var updatedEmp = employeeService.GetEmployeeById(1);
            Console.WriteLine($"Updated Employee: ID: {updatedEmp?.Id}, Name: {updatedEmp?.EmpName}, Department: {updatedEmp?.Department.Name}");
            Console.WriteLine("-------------------------------------------");

            department2.Name = "Human Resources";
            departmentService.UpdateDepartment(department2);
            Console.WriteLine("Department updated successfully.");
            var updatedDept = departmentService.GetDepartmentById(2);
            Console.WriteLine($"Updated Department: ID: {updatedDept?.Id}, Name: {updatedDept?.Name}");
            Console.WriteLine("-------------------------------------------");

            employeeService.DeleteEmployee(2);
            Console.WriteLine("Employee deleted successfully.");
            Console.WriteLine("-------------------------------------------");

            departmentService.DeleteDepartment(2);
            Console.WriteLine("Department deleted successfully."); 
            Console.WriteLine("-------------------------------------------");

            var newEmployees = employeeService.GetAllEmployees();
            Console.WriteLine("Employees:");
            foreach (var emp in newEmployees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.EmpName}, Department: {emp.Department.Name}");
            }
            Console.WriteLine("-------------------------------------------");

            var newDepartments = departmentService.GetAllDepartments();
            Console.WriteLine("Departments:");
            foreach (var dept in newDepartments)
            {
                Console.WriteLine($"ID: {dept.Id}, Name: {dept.Name}");
            }
            Console.WriteLine("-------------------------------------------");
        }
    }
}