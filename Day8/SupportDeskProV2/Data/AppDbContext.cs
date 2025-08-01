using Microsoft.EntityFrameworkCore;
using SupportDeskProV2.Models;

namespace SupportDeskProV2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<TicketHistory> TicketHistories => Set<TicketHistory>();
        public DbSet<CustomerProfile> CustomerProfiles => Set<CustomerProfile>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<TicketAssignment> TicketAssignments => Set<TicketAssignment>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SupportDeskPro;TrustServerCertificate=True;User=sa;Password=YourSecurePassword123!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TicketAssignment (many-to-many User <-> Ticket)
            modelBuilder.Entity<TicketAssignment>(entity =>
            {
                entity.HasKey(ta => new { ta.TicketId, ta.SupportAgentId });

                entity.HasOne(ta => ta.Ticket)
                    .WithMany(t => t.TicketAssignment)
                    .HasForeignKey(ta => ta.TicketId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ta => ta.SupportAgent)
                    .WithMany(u => u.UserId)
                    .HasForeignKey(ta => ta.SupportAgentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}