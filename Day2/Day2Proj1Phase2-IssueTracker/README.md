# 📌 Day2Proj1Phase2 - Issue Tracker System

This is a simple console-based **Issue Tracker System** implemented using C#. The system supports tracking of different types of issues such as Bugs, Tasks, and Feature Requests. Each issue supports reporting and summary generation functionality.

## ✅ Features

- Track different types of issues: `Bug`, `Task`, and `FeatureRequest`.
- Interface-based design using `IReportable` to enforce reporting functionality.
- Input validation inside constructors to ensure object integrity.
- Status tracking (`Open`, `In Progress`, `Closed`) for each issue.
- Displays issue details and status summaries.

---

## 🏗️ Project Structure

```
Day2Proj1Phase2_IssueTracker/
├── Models/
│   ├── Issue.cs              // Base class for all issues
│   ├── Bug.cs                // Represents a Bug with severity
│   ├── Task.cs               // Represents a Task with estimated hours
│   ├── FeatureRequest.cs     // Represents a Feature Request with date and requester
│   └── IReportable.cs        // Interface for reporting functionality
├── Program.cs                // Main application entry point
└── README.md                 // Project documentation
```

---

## 🧪 Sample Output

```
All Issues:
Bug ID: 1:Login Issue | Severity: High
Status: closed
Task #2:Implement Feature X | Estimated Hours: 5
Assigned To: Bob
Status: closed
Feature Request ID: 3:Add Dark Mode | Requested By: Charlie, Expected Release Date: 2023-12-31
Assigned To: Alice
Status: closed

Reporting Status of Issues:
Bug: 1 is under process, it is assigned To: Alice, Severity: High
Task: 2 is under process, it is assigned To: Bob, the estimated hours is 5

Getting Issues status:
In Progress: 2, Closed: 1, Open: 0
```

---

## 🚀 How to Run

1. Open the solution in **Visual Studio** or any C# IDE.
2. Build the project.
3. Run the console app.
4. Observe the status output for each issue type.

---

## 📚 Concepts Used

- **OOP Concepts**: Inheritance, Polymorphism, Encapsulation
- **Interfaces**: `IReportable`
- **Constructor Input Validation**
- **List Collection & Iteration**
- **Console I/O**

---

## 👨‍💻 Author

- **Adhnan Jeff**
- Project developed as part of .NET Training Day 2, Phase 2.

---

## 📝 License

This project is for educational purposes. Free to use and modify.