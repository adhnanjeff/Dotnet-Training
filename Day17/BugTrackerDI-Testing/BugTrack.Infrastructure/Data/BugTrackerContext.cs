using BugTrack.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTrack.Infrastructure.Data
{
    public class BugTrackerContext : DbContext
    {
        public BugTrackerContext(DbContextOptions<BugTrackerContext> options) : base(options)
        {
        }
        public DbSet<Bug> Bugs => Set<Bug>();
        public DbSet<Project> Projects => Set<Project>();
    }
}
