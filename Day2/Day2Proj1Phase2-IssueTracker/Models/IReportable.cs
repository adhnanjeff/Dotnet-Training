using System;

namespace Day2Proj1Phase2_IssueTracker.Models
{
    public interface IReportable
    {
        void ReportStatus();
        void getSummary();
    }
}