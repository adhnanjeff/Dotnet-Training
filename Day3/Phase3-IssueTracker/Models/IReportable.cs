using System;

namespace Phase3_IssueTracker.Models
{
    public interface IReportable
    {
        void ReportStatus();
        void getSummary();
    }
}