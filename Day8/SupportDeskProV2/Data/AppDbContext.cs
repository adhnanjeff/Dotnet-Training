using System;

using Microsoft.EntityFrameworkCore;
using SupportDeskProV2.Models;
namespace SupportDeskProV2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<TicketTag> TicketSupportAgents => Set<TicketTag>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SupportDeskPro;TrustServerCertificate=True;User=sa;Password=YourSecurePassword123!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketSupportAgent>()
                .HasKey(tsa => new { tsa.TicketId, tsa.SupportAgentId });

            modelBuilder.Entity<TicketSupportAgent>()
                .HasOne(tsa => tsa.Ticket)
                .WithMany(t => t.TicketSupportAgents)
                .HasForeignKey(tsa => tsa.TicketId);

            modelBuilder.Entity<TicketSupportAgent>()
                .HasOne(tsa => tsa.SupportAgent)
                .WithMany(sa => sa.TicketSupportAgents)
                .HasForeignKey(tsa => tsa.SupportAgentId);
        }
    }
}