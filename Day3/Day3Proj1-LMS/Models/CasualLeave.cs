using System;
namespace Day3Proj1_LMS.Models
{
    public class CasualLeave : LeaveRequest, IApprovable
    {
        public string Reason { get; set; }
        public CasualLeave(int id, string employeeName, int daysReq, string reason) : base(id, employeeName, daysReq)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Doctor's note cannot be empty.", nameof(reason));
            Reason = reason;
        }
        // Implementing the IApprovable interface method
        public void ShowApprovalStatus()
        {
            Console.WriteLine($"Sick Leave Request ID: {Id} is currently {Status}.");
        }
        public override void Display()
        {
            Console.WriteLine($"Sick Leave Request ID: {Id}");
            Console.WriteLine($"Employee Name: {EmployeeName}");
            Console.WriteLine($"Days Requested: {DaysRequested}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Doctor's Note: {Reason}");
        }
    }
}