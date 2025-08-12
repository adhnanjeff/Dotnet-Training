using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrack.Core.Entities
{
    public class Bug
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string Status { get; set; } = "Open";
        public required int ProjectId { get; set; }
        public Project? ProjectName { get; set; }
    }
}
