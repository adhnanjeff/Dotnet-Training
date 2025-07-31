# 🛠️ SupportDesk Phase 1

This is a simple C# console application that simulates a basic support desk system using Entity Framework Core. It demonstrates relationships between **Users**, **Tickets**, **Tags**, and the **TicketTags** join table.

## 📚 Overview

The application:

- Initializes a new in-memory database context.
- Clears any existing records from the database.
- Creates a new user, ticket, and tags.
- Links the ticket to multiple tags using a join table.
- Outputs ticket information with associated tags.

## 🗃️ Database Entities

### 1. `User`
Represents a person who raises support tickets.

### 2. `Ticket`
Represents a support ticket raised by a user.

### 3. `Tag`
Represents a category or label (e.g., "Bug", "UI").

### 4. `TicketTag`
Join table to associate many-to-many relationships between `Tickets` and `Tags`.

## 🧩 Key Code Features

```csharp
// Add a new user
User user = new User {
    UserName = "Jeff",
};

// Add a ticket and associate it with the user
Ticket ticket = new Ticket {
    Title = "Login Issue",
    UserId = 1,
    User = user
};

// Add multiple tags
var tags = new [] {
    new Tag { TagName = "Bug" },
    new Tag { TagName = "UI" }
};

// Create ticket-tag relationships
var ticketTag1 = new TicketTag {
    Ticket = ticket,
    Tag = tags[0]
};
var ticketTag2 = new TicketTag {
    Ticket = ticket,
    Tag = tags[1]
};
```

## 📥 Output Example

```
Ticket: Login Issue raised by Jeff
 - Tag: Bug
 - Tag: UI
```

## 🏗️ Tech Stack

- C#
- .NET Core
- Entity Framework Core
- In-Memory Database (for demonstration)

## 🚀 How to Run

1. Ensure you have [.NET SDK](https://dotnet.microsoft.com/download) installed.
2. Clone the project.
3. Open in Visual Studio or use CLI.
4. Run the project:  
   ```bash
   dotnet run
   ```