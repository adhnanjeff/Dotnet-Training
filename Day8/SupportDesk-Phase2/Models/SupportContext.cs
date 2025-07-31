using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SupportDesk_Phase2.Models
{
    public partial class SupportContext : DbContext
    {
        public SupportContext()
        {
        }

        public SupportContext(DbContextOptions<SupportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketHistory> TicketHistories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost;Database=SupportDeskDB;TrustServerCertificate=True;User=sa;Password=YourSecurePassword123!");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerProfile>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__Customer__A4AE64D87FFF19CC");

                entity.ToTable("CustomerProfile");

                entity.Property(e => e.UserId).ValueGeneratedNever();
                entity.Property(e => e.Address).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.User).WithOne(p => p.CustomerProfile)
                    .HasForeignKey<CustomerProfile>(d => d.UserId)
                    .HasConstraintName("FK__CustomerP__Custo__6E01572D");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId).HasName("PK__Departme__014881AE60C3E409");

                entity.ToTable("Department");

                entity.Property(e => e.DeptName).HasMaxLength(50);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.TagId).HasName("PK__Tags__657CF9AC81D43061");

                entity.Property(e => e.TagName).HasMaxLength(100);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC6072D351E2B");

                entity.Property(e => e.Title).HasMaxLength(200);

                // Raised by user
                entity.HasOne(d => d.RaisedBy)
                    .WithMany(p => p.TicketsRaised)
                    .HasForeignKey(d => d.RaisedById)
                    .HasConstraintName("FK__Tickets__UserId__398D8EEE");

                // Assigned to user
                entity.HasOne(d => d.AssignedTo)
                    .WithMany(p => p.TicketsAssigned)
                    .HasForeignKey(d => d.AssignedToId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tickets_AssignedTo");

                // Tags many-to-many
                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Tickets)
                    .UsingEntity<Dictionary<string, object>>(
                        "TicketTag",
                        r => r.HasOne<Tag>().WithMany()
                            .HasForeignKey("TagId")
                            .HasConstraintName("FK__TicketTag__TagId__4316F928"),
                        l => l.HasOne<Ticket>().WithMany()
                            .HasForeignKey("TicketId")
                            .HasConstraintName("FK__TicketTag__Ticke__4222D4EF"),
                        j =>
                        {
                            j.HasKey("TicketId", "TagId").HasName("PK__TicketTa__A77B099D92140B7D");
                            j.ToTable("TicketTags");
                        });
            });

            modelBuilder.Entity<TicketHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId).HasName("PK__TicketHi__4D7B4ABD8A6B7C8F");

                entity.ToTable("TicketHistory");

                entity.Property(e => e.TicketDesc).HasMaxLength(100);
                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketHistories)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__TicketHis__Ticke__4E88ABD4");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CB2FC0D28");

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .HasDefaultValue("Customer");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
