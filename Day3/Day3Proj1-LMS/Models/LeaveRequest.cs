using System;
namespace Day3Proj1_LMS.Models {
    public abstract class LeaveRequest {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int DaysRequested { get; set; }
        public string Status { get; set; } // e.g., "Pending", "Approved", "Rejected"
        public LeaveRequest(int id, string employeeName, int daysReq) {
            if (id <= 0)
                throw new ArgumentException("ID must be a positive integer.", nameof(id));
            if (string.IsNullOrWhiteSpace(employeeName))
                throw new ArgumentException("Employee name cannot be empty.", nameof(employeeName));
            if(daysReq <= 0)
                throw new ArgumentException("Days requested must be greater than zero.", nameof(daysReq));
            Id = id;
            EmployeeName = employeeName;
            DaysRequested = daysReq;
            Status = "Pending"; // Default status
        }
        public void Approve() => Status = "Approved";
        public void Reject() => Status = "Rejected";
        public abstract void Display();
    }
}