using BugStatistics.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugStatistics.Core.Interfaces
{
    public interface IBugRepository
    {
        public List<Bug> GetAll();
        public List<Bug> GetBugsById(int id);
    }
}
