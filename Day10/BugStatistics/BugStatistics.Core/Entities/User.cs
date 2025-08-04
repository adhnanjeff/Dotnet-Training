using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugStatistics.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
    }
}
