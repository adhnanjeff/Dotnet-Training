using System;
using System.Collections.Generic;
using Day3Proj1_LMS.Models;
namespace Day3Proj1_LMS.Services;

public interface ILeaveService {
    public void DisplayAllLeaves(List<LeaveRequest> req);
    void ShowApprovals(List<IApprovable> approvables);
}