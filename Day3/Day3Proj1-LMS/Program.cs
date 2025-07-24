
using Day3Proj1_LMS.Models;
using Day3Proj1_LMS.Services;
using System;
using System.Collections;

public class Program
{
    public static void Main(string[] args) {
        SickLeave leave1 = new SickLeave(1, "Subashini", 5, "Scraped Knee");
        CasualLeave leave2 = new CasualLeave(2, "Jeff", 3, "Summa");

        List<LeaveRequest> leaveRequests = new List<LeaveRequest> { leave1, leave2 };
        List<IApprovable> approvals = new List<IApprovable> { leave1, leave2 };

        Console.WriteLine("Leave Requests:");
        LeaveService leaveService = new LeaveService();
        leaveService.DisplayAllLeaves(leaveRequests);
        
        Console.WriteLine("Processing Leave Requests...");
        foreach(var leave in leaveRequests) {
            /* leave.ShowApprovalStatus();  --> This does not work here because we have used an 
                                                 abstract class and not a base class so we need 
                                                 to create an object to hold objects of interface
            List<IApprovable> approvableRequests = new List<IApprovable> { leave1, leave2 };
            or as the following*/
            if(leave is IApprovable approvableLeave) {
                approvableLeave.ShowApprovalStatus();
            } else {
                Console.WriteLine("This leave request cannot be approved.");
            }
        }

        foreach (var leave in leaveRequests) {
            
            if (leave is SickLeave sick) {
                Console.WriteLine($"Sick Leave - Reason: {sick.DoctorNote}");
                sick.Approve();
            }
            else if (leave is CasualLeave casual) {
                Console.WriteLine($"Casual Leave - Reason: {casual.Reason}");
                casual.Reject();
            }
        }
        leaveService.ShowApprovals(approvals);
    }
}

