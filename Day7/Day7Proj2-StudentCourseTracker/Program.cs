using System;
using Day7Proj2_StudentCourseTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCoreDbPhase2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new CourseContext())
            {
                // Clear old data
                context.Courses.RemoveRange(context.Courses);
                context.Students.RemoveRange(context.Students);
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Student', RESEED, 0)");
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Course', RESEED, 0)");
                context.SaveChanges();

                var coursesToAdd = new[]
                {
                    new Course { CourseName = "C#" },
                    new Course { CourseName = "Java" },
                    new Course { CourseName = "Python" }
                };
                context.Courses.AddRange(coursesToAdd);
                context.SaveChanges();
                Console.WriteLine("----- Courses Added -----");

                while (true)
                {
                    Console.WriteLine("1. Add a Student" +
                                      "\n2. View All Students" +
                                      "\n3. Delete a Student" +
                                      "\n4. Update a Student" +
                                      "\n5. View All courses" +
                                      "\n6. Exit");
                    Console.Write("Enter your choice: ");
                    var choice = Console.ReadLine();
                    switch(choice)
                    {
                        case "1": 
                            Console.Write("Enter Student Name: ");
                            var studentName = Console.ReadLine();
                            Console.Write("Enter Student Age: ");
                            var studentAge = int.Parse(Console.ReadLine());
                            Console.Write("Enter Course Id (1 for C#, 2 for Java, 3 for Python): ");
                            var courseId = int.Parse(Console.ReadLine());
                            var student = new Student
                            {
                                StudentName = studentName,
                                Age = studentAge,
                                CourseId = courseId
                            };
                            context.Students.Add(student);
                            context.SaveChanges();
                            Console.WriteLine("Student added successfully!");
                            break;

                        case "2": 
                            Console.WriteLine("----- All Students -----");
                            var students = context.Students
                                .Include(s => s.Course)
                                .ToList();
                            foreach (var stud in students)
                            {
                                Console.WriteLine($"Id: {stud.StudentId}, Name: {stud.StudentName}, Age: {stud.Age}, Course: {stud.Course?.CourseName}");
                            }
                            break;

                        case "3":
                            Console.Write("Enter Student Id to delete: ");
                            var studentId = int.Parse(Console.ReadLine());
                            var studentToDelete = context.Students.Find(studentId);
                            if (studentToDelete != null)
                            {
                                context.Students.Remove(studentToDelete);
                                context.SaveChanges();
                                Console.WriteLine("Student deleted successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Student not found!");
                            }
                            break;

                        case "4":
                            Console.Write("Enter Student Id to update: ");
                            var updateStudentId = int.Parse(Console.ReadLine());
                            var studentToUpdate = context.Students.Find(updateStudentId);
                            if(studentToUpdate != null)
                            {
                                Console.WriteLine("Enter new Student Name (leave blank to keep current): ");
                                var newName = Console.ReadLine();
                                studentToUpdate.StudentName = string.IsNullOrWhiteSpace(newName) ? studentToUpdate.StudentName : newName;
                                Console.WriteLine("Enter new Age (0 to keep current): ");
                                var newAgeInput = int.Parse(Console.ReadLine());
                                studentToUpdate.Age = newAgeInput == 0 ? studentToUpdate.Age : newAgeInput;
                                Console.WriteLine("Enter new Course Id (0 to keep current): ");
                                var newCourseIdInput = int.Parse(Console.ReadLine());
                                studentToUpdate.CourseId = newCourseIdInput == 0 ? studentToUpdate.CourseId : newCourseIdInput;
                                context.SaveChanges();
                                Console.WriteLine("Student updated successfully!");
                            }
                            break;

                        case "5":
                            Console.WriteLine("----- All Courses -----");
                            var courses = context.Courses.ToList();
                            foreach(var course in courses) 
                            {
                                Console.WriteLine($"Id: {course.CourseId}, Course: {course.CourseName}");
                            }
                            break;

                        case "6":
                            Console.WriteLine("Exiting...");
                            return;
                    }
                }
            }
        }
    }
}
