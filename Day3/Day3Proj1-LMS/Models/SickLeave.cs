using System;
namespace Day3Proj1_LMS.Models
{
    public class SickLeave : LeaveRequest, IApprovable {
        public string DoctorNote { get; set; } 
        public SickLeave(int id, string employeeName, int daysReq, string docNote) : base(id, employeeName, daysReq) {
            if (string.IsNullOrWhiteSpace(docNote))
                throw new ArgumentException("Doctor's note cannot be empty.", nameof(docNote));
            DoctorNote = docNote;
        }
        // Implementing the IApprovable interface method
        public void ShowApprovalStatus() {
            Console.WriteLine($"Sick Leave Request ID: {Id} is currently {Status}.");
        }
        public override void Display() {
            Console.WriteLine($"Sick Leave Request ID: {Id}");
            Console.WriteLine($"Employee Name: {EmployeeName}");
            Console.WriteLine($"Days Requested: {DaysRequested}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Doctor's Note: {DoctorNote}");
        }
    }
}