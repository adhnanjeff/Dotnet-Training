using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugStatisticsDashboard.Core.Entity
{
    public class Bug
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ProjectName { get; set; }
        public required string Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public required string Priority { get; set; } 
        public required string AssignedTo { get; set; } 
        
    }
}
