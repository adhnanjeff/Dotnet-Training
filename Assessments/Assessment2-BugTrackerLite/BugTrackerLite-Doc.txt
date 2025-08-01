# BugTrackerLite Console Application Documentation

## Overview

**BugTrackerLite** is a console-based ticket management system that allows users to create tickets, associate tags, and manage the status of those tickets. This is designed to mimic a lightweight bug-tracking system. The system supports basic CRUD operations, entity relationships, and demonstrates use of Entity Framework Core with SQL Server.

---

## Project Structure

```
Assessment2-BugTrackerLite/
|
|-- bin/
|-- obj/
|-- Data/
|   |-- AppDbContext.cs         # Custom DbContext with fluent config for join entity TicketTag
|
|-- Models/
|   |-- BugTrackerLiteDbContext.cs  # Auto-generated context from scaffolding
|   |-- Tag.cs
|   |-- Ticket.cs
|   |-- TicketTag.cs
|   |-- User.cs
|
|-- Program.cs                 # Main console UI and logic
|-- SQLQuery.sql               # SQL script to generate initial DB schema
```

---

## Technologies Used

- **.NET 9.0 Console Application**
- **Entity Framework Core**
- **SQL Server**

---

## Setup Instructions

### 1. Database Setup

Run the SQL script from `SQLQuery.sql` to create and initialize the `BugTrackerLiteDB` database.

```sql
CREATE DATABASE BugTrackerLiteDB;
USE BugTrackerLiteDB;

-- Create tables
CREATE DATABASE BugTrackerLiteDB;


USE BugTrackerLiteDB;


CREATE TABLE Users(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL
);

CREATE TABLE Tickets(
    TicketId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    TicketDesc NVARCHAR(200) NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    CreatedDate DATE,
    UserId INT,

    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Tags(
    TagId INT IDENTITY(1,1) PRIMARY KEY,
    TagName NVARCHAR(100) NOT NULL
);

CREATE TABLE TicketTags (
    TicketId INT NOT NULL,
    TagId INT NOT NULL,
    PRIMARY KEY (TicketId, TagId),
    FOREIGN KEY (TicketId) REFERENCES Tickets(TicketId) ON DELETE CASCADE,
    FOREIGN KEY (TagId) REFERENCES Tags(TagId) ON DELETE CASCADE
);


SELECT * FROM Users;
SELECT * FROM Tags;
SELECT * FROM Tickets;
SELECT * FROM TicketTags;
```

### 2. Install Required Packages

Run the following commands from your terminal inside the project directory:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet add package Microsoft.EntityFrameworkCore.Design
```

### 3. Scaffold Existing Database

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=BugTrackerLiteDB;TrustServerCertificate=True;User=sa;Password=YourSecurePassword123!" Microsoft.EntityFrameworkCore.SqlServer -o Models -f
```

This generates `Models` folder with:

- Entities: `Tag`, `Ticket`, `User`
- DbContext: `BugTrackerLiteDbContext`

> ⚠️ Pure join table `TicketTags` won’t be scaffolded automatically.

---

## Step-by-Step Process

### Step 1: Create Relations

Define schema using `SQLQuery.sql`. This includes many-to-many relationship between `Tickets` and `Tags` via `TicketTags`.

### Step 2: Install Packages

Install Entity Framework Core packages as listed above.

### Step 3: Perform Scaffolding

Generate model classes and DbContext from SQL schema using the scaffold command.

### Step 4: Create Join Entity Manually

Create `TicketTag.cs` in Models:

```csharp
public class TicketTag {
    public int TicketId { get; set; }
    public int TagId { get; set; }
    public Ticket Ticket { get; set; }
    public Tag Tag { get; set; }
}
```

Create `AppDbContext.cs` in Data:

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

### Step 5: Menu-Driven Console Application

Implemented in `Program.cs`:

**Menu Options:**

1. Create User
2. Create Ticket
3. Add Tags and TicketTags
4. Resolve Ticket
5. View All Tickets with Tags
6. Exit

---

## Features Summary

### Create User

Prompts for a user name and saves it.

### Create Ticket

- Prompts user to select a user
- Accepts ticket title and description
- Saves ticket with `Status = Open` and current date

### Add Tags & TicketTags

- Creates tags
- Associates them with an existing ticket

### Resolve Ticket

- Displays tickets with `Status = Open`
- Lets user mark one as `Resolved`

### View All Tickets with Tags

Displays all tickets with their user and related tags.

---

## Known Considerations

- Connection string is hard-coded (should be externalized in production)
- No exception handling for invalid inputs
- Assumes tags are unique by name (no validation implemented)
- Only one ticket is used when associating tags (for simplicity)

---

## Future Enhancements

- Add validation and error handling
- Filter tickets by user or status
- Implement editing and deletion
- Add priority or category fields
- Add reporting (e.g. ticket counts per user or tag)

---

## Authors & Maintainers

- Adhnan Jeff 
- Developed for **Assessment 2 - .NET Training**
- GitHub: [https://github.com/adhnanjeff/Dotnet-Training/tree/main/Assessments/Assessment2-BugTrackerLite](https://github.com/adhnanjeff/Dotnet-Training/tree/main/Assessments/Assessment2-BugTrackerLite)

