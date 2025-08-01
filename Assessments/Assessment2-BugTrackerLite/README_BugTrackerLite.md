
# BugTrackerLite Console Application

BugTrackerLite is a .NET 9.0 console application that functions as a lightweight bug-tracking system. It allows users to create tickets, assign tags, and manage ticket statuses using Entity Framework Core and SQL Server.

---

## 📁 Project Structure

```
Assessment2-BugTrackerLite/
├── Data/
│   └── AppDbContext.cs
├── Models/
│   ├── BugTrackerLiteDbContext.cs
│   ├── Tag.cs
│   ├── Ticket.cs
│   ├── TicketTag.cs
│   └── User.cs
├── Program.cs
├── SQLQuery.sql
```

---

## ⚙️ Technologies Used

- .NET 9.0 Console App
- Entity Framework Core
- SQL Server

---

## 🚀 Getting Started

### 1. Database Setup

Run the SQL script (`SQLQuery.sql`) to create the initial schema:

```sql
CREATE DATABASE BugTrackerLiteDB;
USE BugTrackerLiteDB;

-- Add table creation scripts here
```

### 2. Install EF Core Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### 3. Scaffold Existing Database

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=BugTrackerLiteDB;TrustServerCertificate=True;User=sa;Password=YourSecurePassword123!" Microsoft.EntityFrameworkCore.SqlServer -o Models -f
```

> ⚠️ Pure join table `TicketTags` will not be scaffolded automatically.

---

## 🛠 Manual Setup for Join Table

Create `TicketTag.cs` in `Models`:

```csharp
public class TicketTag {
    public int TicketId { get; set; }
    public int TagId { get; set; }
    public Ticket Ticket { get; set; }
    public Tag Tag { get; set; }
}
```

Create `AppDbContext.cs` in `Data/`:

```csharp
public class AppDbContext : BugTrackerLiteDbContext {
    public DbSet<TicketTag> TicketTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

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
    }
}
```

---

## 🧑‍💻 Console Menu Features

- ✅ Create User
- 📝 Create Ticket
- 🔖 Add Tags and TicketTags
- ✅ Resolve Ticket
- 📋 View All Tickets with Tags

---

## 📌 Limitations

- No input validation or exception handling
- Hardcoded connection string
- Tag uniqueness is not enforced
- Only basic CRUD operations supported

---

## 🧱 Future Enhancements

- Add Priority and Status filters
- Add role-based access (Admin/User)
- Export reports (e.g. Ticket by Tag/User)
- Include Unit Tests

---

## 👨‍💻 Author

Developed by **Adhnan Jeff**  
For **Assessment 2 - .NET Training**  
GitHub Repo: [BugTrackerLite](https://github.com/adhnanjeff/Dotnet-Training/tree/main/Assessments/Assessment2-BugTrackerLite)
