# 📌 Day2Proj2 - SupportDeskPro

**SupportDeskPro** is a modular and extensible ticketing system developed as part of the .NET training assignment for **Day 2 – Project 2**. It applies object-oriented programming principles, interface implementation, and polymorphism.

---

## ✅ Project Requirements

### 1. **Base Class** – `SupportTicket`
- **Properties**:
  - `Id`
  - `Title`
  - `Description`
  - `CreatedBy`
  - `Status`
- **Methods**:
  - `DisplayDetails()` – marked as `virtual` for polymorphic behavior
  - `CloseTicket()` – updates ticket status to `Closed`

---

### 2. **Derived Classes**
- **`BugReport`**:
  - Adds: `Severity`
  - Implements: `IReportable`

- **`FeatureRequest`**:
  - Adds: `RequestedBy`, `ETA`
  - Implements: `IReportable`

---

### 3. **Interface** – `IReportable`
- Method:
  - `ReportStatus()` – used for ticket reporting purposes

---

### 4. **Polymorphism**
- A `List<SupportTicket>` is used to hold mixed objects (`BugReport`, `FeatureRequest`) and invoke their overridden methods using base class reference.

---

### 5. **Program.cs**
- Creates objects of `BugReport` and `FeatureRequest`
- Displays details
- Reports statuses
- Closes tickets and displays updated statuses

---

## 🏗️ Folder Structure

```
Day2Proj2_SupportDeskPro/
├── Models/
│   ├── SupportTicket.cs
│   ├── BugReport.cs
│   ├── FeatureRequest.cs
│   └── IReportable.cs
└── Program.cs
```

---

## 🧪 Sample Output

```
[BUG] Ticket ID: 101
Title: Login not working
Severity: High
Created By: Alice
Status: Open
Status Report: In Progress

[FEATURE] Ticket ID: 102
Title: Add Export Option
Requested By: Bob
ETA: 2023-12-31
Status: Open
Status Report: In Progress

Closing tickets...
Updated Status:
Ticket ID: 101 - Closed
Ticket ID: 102 - Closed
```

---

## 📚 Concepts Used

- Object-Oriented Programming (Inheritance, Polymorphism)
- Interface Implementation
- Method Overriding
- Console Application in C#
- Git-based modular project structure

---

## 🛠️ How to Run

1. Open in **Visual Studio** or preferred IDE.
2. Build and run the application.
3. Observe ticket creation, reporting, and closure simulation in console.

---

## 👨‍💻 Author

- **Adhnan Jeff**
- Assignment developed for training on advanced C# practices.

---

## 📝 License

Educational use only. Feel free to reuse or modify for learning purposes.