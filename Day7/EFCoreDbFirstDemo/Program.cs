using System;
using EFCoreDbFirstDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDbFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new CompanyContext();
            Console.WriteLine("----- All Employees with Department Info -----");
            var employees = context.Employees
                .Include(e => e.Dept) 
                .ToList(); 

            foreach (var emp in employees) {
                Console.WriteLine($"Id: {emp.EmpId}, Employee: {emp.EmpName}, Age: {emp.Age}, Department: {emp.Dept?.DeptName}");
            }



            //using (var context = new CompanyContext()) // Create a new instance of the context for the class which has all DB details
            //{
            //    Console.WriteLine("----- All Employees with Department Info -----");
            //    // Ensure database is created
            //    context.Database.EnsureCreated();
            //    // Add a new department
            //    var department = new Department { DeptName = "Human Resources" };
            //    context.Departments.Add(department);
            //    context.SaveChanges();
            //    // Add a new employee
            //    var employee = new Employee { EmpName = "John Doe", Age = 30, DeptId = department.DeptId };
            //    context.Employees.Add(employee);
            //    context.SaveChanges();
            //    // Query and display data
            //    foreach (var emp in context.Employees.Include(e => e.Dept))
            //    {
            //        Console.WriteLine($"Employee: {emp.EmpName}, Age: {emp.Age}, Department: {emp.Dept?.DeptName}");
            //    }
            //}
        }
    }
}