using Microsoft.EntityFrameworkCore;
using SupportDesk_Phase2.Models;

namespace SupportDesk_Phase2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<TicketTag> TicketTags => Set<TicketTag>();
        public DbSet<TicketHistory> TicketHistories => Set<TicketHistory>();
        public DbSet<CustomerProfile> CustomerProfiles => Set<CustomerProfile>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SupportDeskDB;TrustServerCertificate=True;User=sa;Password=YourSecurePassword123!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TicketTag many-to-many
            modelBuilder.Entity<TicketTag>()
                .HasKey(tt => new { tt.TicketId, tt.TagId });

            modelBuilder.Entity<TicketTag>()
                .HasOne(tt => tt.Ticket)
                .WithMany(t => t.TicketTags)
                .HasForeignKey(tt => tt.TicketId);

            modelBuilder.Entity<TicketTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TicketTags)
                .HasForeignKey(tt => tt.TagId);

            // User ↔ CustomerProfile (1:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.CustomerProfile)
                .WithOne(cp => cp.User)
                .HasForeignKey<CustomerProfile>(cp => cp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Ticket raised by user (RaisedBy)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.RaisedBy)
                .WithMany(u => u.TicketsRaised)
                .HasForeignKey(t => t.RaisedById)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Tickets_RaisedBy");

            // Ticket assigned to user (AssignedTo)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.AssignedTo)
                .WithMany(u => u.TicketsAssigned)
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Tickets_AssignedTo");
        }
    }
}
