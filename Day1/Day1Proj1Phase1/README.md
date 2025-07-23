
# Ticket Management System - Phase 1

This is a simple **Ticket Management System (Phase 1)** built using C# that demonstrates basic object-oriented programming concepts such as class definition, object instantiation, encapsulation, and method invocation.

## 🚀 Features

- Create users and tickets
- Display ticket and user information
- Change ticket status (New → Closed)
- Structured using separate model classes

## 🧱 Project Structure

```
Day1Proj1Phase1/
│
├── Models/
│   ├── Ticket.cs       # Contains the Ticket class
│   └── User.cs         # Contains the User class
│
└── Program.cs          # Main application logic
```

## 📄 Classes Overview

### `User` Class
Represents a user who can create tickets.

**Properties:**
- `Id` (int)
- `Name` (string)
- `Role` (string)

**Method:**
- `DisplayUser(User user)` — Displays user information

### `Ticket` Class
Represents a support or feature ticket.

**Properties:**
- `TicketId` (int)
- `Title` (string)
- `Description` (string)
- `Status` (string)
- `CreatedBy` (User)

**Methods:**
- `closeTicket()` — Changes status to "Closed"
- `DisplayTicket(Ticket ticket)` — Displays ticket information

## 💻 How It Works

1. A `User` is created.
2. A `Ticket` is raised by that user.
3. Ticket info is displayed.
4. The ticket is closed using `closeTicket()`.
5. Ticket info is displayed again to reflect the updated status.

## 🛠 Technologies Used

- C#
- .NET Console Application

## 📦 Usage

To run this project:
1. Open it in Visual Studio or your C# IDE.
2. Build and run the solution.
3. View the output in the terminal.

## 🔚 Output Example

```
------ Ticket Info ------
TicketId: 101
Title: Bug in Login
Description: Unable to login with valid credentials
Status: New
Created By:
Id: 1, Name: Alice, Role: Developer

After closing the ticket:
------ Ticket Info ------
TicketId: 101
Title: Bug in Login
Description: Unable to login with valid credentials
Status: Closed
Created By:
Id: 1, Name: Alice, Role: Developer
```

---

📁 **Author**: Adhnan Jeff
📅 **Phase**: 1
