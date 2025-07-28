using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IssueTracker.Core.Entities;
using System.Threading.Tasks;

namespace IssueTracker.Core.Interfaces
{
    public interface IBugRepository
    {
        List<Bug> GetAll();
        Bug GetBugById(int id);
        void AddBug(Bug bug);
        void UpdateBug(Bug bug);
        void DeleteBug(int id);
    }
}
