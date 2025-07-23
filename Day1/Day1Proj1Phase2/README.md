<<<<<<< HEAD

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
=======
# 🎟️ Ticket Management System - Day1Proj1Phase1

A simple console-based Ticket Management System built with C# for training and demonstration purposes. This project simulates basic ticket operations like creation, reassignment, and closure, mimicking a real-world software ticket tracking workflow.

---

## 📁 Project Structure

```
Day1Proj1Phase2/
│
├── Models/
│   ├── Ticket.cs       // Defines the Ticket class and related operations
│   └── User.cs         // Defines the User class
│
└── Program.cs          // Main entry point for running the ticket system simulation
>>>>>>> 83b388855fb8729bfb8fce47a9f8b3d096fa0bb6
```

---

<<<<<<< HEAD
📁 **Author**: Adhnan Jeff
📅 **Phase**: 1
=======
## 🛠️ Features

- ✅ Create new tickets with title, description, priority, and assignment
- 🔄 Reassign tickets to different users
- 🟢 View ticket summaries with metadata
- 🔒 Close tickets and record resolution time
- 👤 Simple user roles: Developer, Tester, Manager

---

## 🧾 Classes Overview

### 🧑‍💻 `User.cs`
Represents a user in the system.

```csharp
public class User
{
    public int Id;
    public string Name;
    public string Role;
}
```

### 🧾 `Ticket.cs`
Represents a ticket with properties like ID, status, assignee, and timestamps.

Key Methods:
- `DisplaySummary()`
- `ReassignTicket()`
- `CloseTicket()`

---

## 🚀 How It Works

1. Three users are created: Alice (Developer), Bob (Tester), Charlie (Manager).
2. Three tickets are initialized with different priorities and assignments.
3. Ticket summaries are displayed before and after reassignment.
4. All tickets are closed and the summaries updated.

---

## 🧪 Sample Output

```
----- Ticket Summary Before Reassignment -----
Ticket #101: Bug in Login - New - HIGH - Assigned to: Bob
   Created On: 7/22/2025 3:55:00 PM

Ticket #102: Feature Request - New - MEDIUM - Assigned to: Charlie
   Created On: 7/22/2025 3:55:01 PM

...

----- Reassigning Tickets -----
Ticket #101 has been reassigned to Charlie.
Ticket #102 has been reassigned to Alice.

----- Ticket Summary After Closing -----
Ticket #101: Bug in Login - Closed - HIGH - Assigned to: Charlie
```

---

## 📦 Requirements

- .NET 6.0 SDK or later
- Windows/Linux/Mac terminal (any C# compatible environment)

---

## 🧰 How to Run

1. Clone or download the repository.
2. Navigate to the project directory:

   ```bash
   cd Day1Proj1Phase2
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

4. Run the app:

   ```bash
   dotnet run
   ```

---

## 📝 Future Enhancements (Optional Ideas)

- Add ticket resolution time calculation
- Implement persistent storage (e.g., JSON or DB)
- Add filtering and sorting by status or priority
- GUI version using Windows Forms or WPF

---

## 👨‍💻 Author

- **Adhnan Jeff**
- GitHub: [adhnanjeff](https://github.com/adhnanjeff)

---
>>>>>>> 83b388855fb8729bfb8fce47a9f8b3d096fa0bb6
