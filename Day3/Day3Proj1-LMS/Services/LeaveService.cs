using System;
using System.Collections.Generic;
using Day3Proj1_LMS.Models;
namespace Day3Proj1_LMS.Services
{
    public class LeaveService : ILeaveService {
        public void DisplayAllLeaves(List<LeaveRequest> req) {
            if (req == null || req.Count == 0) {
                Console.WriteLine("No leave requests to display.");
                return;
            }
            foreach (var leave in req) {
                leave.Display();
                Console.WriteLine();
            }
        }

        public void ShowApprovals(List<IApprovable> approvables) {
            if(approvables == null) {
                Console.WriteLine("No approved requests yet");
                return;
            }
            foreach(var approvable in approvables) {
                approvable.ShowApprovalStatus();
            }
            Console.WriteLine();
        }
    }
}