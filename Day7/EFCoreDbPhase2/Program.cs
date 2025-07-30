using System;
using EFCoreDbPhase2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCoreDbPhase2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new CompanyContext())
            {
                // Clear old data
                context.Employees.RemoveRange(context.Employees);
                context.Departments.RemoveRange(context.Departments);
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Employees', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Department', RESEED, 0)");
                context.SaveChanges();

                var departmentsToAdd = new[]
                {
                    new Department { DeptName = "IT" },
                    new Department { DeptName = "HR" },
                    new Department { DeptName = "Sales" }
                };

                context.Departments.AddRange(departmentsToAdd);
                context.SaveChanges();

                Console.WriteLine("----- Departments Added -----");
                var departments = context.Departments.ToList();
                foreach (var dept in departments)
                {
                    Console.WriteLine($"Id: {dept.DeptId}, Department: {dept.DeptName}");
                }

                var employeesToAdd = new[]
                {
                    new Employee { EmpName = "Ahalya", Age = 21, DeptId = departments[1].DeptId }, 
                    new Employee { EmpName = "Amrith", Age = 21, DeptId = departments[0].DeptId }, 
                    new Employee { EmpName = "Bhavya", Age = 21, DeptId = departments[2].DeptId }  
                };

                context.Employees.AddRange(employeesToAdd);
                context.SaveChanges();

                Console.WriteLine("\nEmployees added successfully!\n");

                Console.WriteLine("----- All Employees with Department Info -----");
                var employees = context.Employees
                    .Include(e => e.Dept)
                    .ToList();

                foreach (var emp in employees)
                {
                    Console.WriteLine($"Id: {emp.EmpId}, Employee: {emp.EmpName}, Age: {emp.Age}, Department: {emp.Dept?.DeptName}");
                }
            }
        }
    }
}
