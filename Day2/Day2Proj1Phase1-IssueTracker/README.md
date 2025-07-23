
# Issue Tracker - Phase 1

This project demonstrates the use of object-oriented principles like inheritance, interfaces, and polymorphism in C#.

## 📁 Structure

The project consists of the following components in the `Day2Proj1Phase1_IssueTracker.Models` namespace:

- `Issue` (Base class for all issues)
- `Bug` (Derived class representing a bug)
- `Task` (Derived class representing a task)
- `IReportable` (Interface implemented by `Bug` and `Task`)

## ▶️ Program Overview

The `Program.cs` file creates instances of `Bug` and `Task`, adds them to a list of issues, and demonstrates polymorphism by calling the `Display` and `ReportStatus` methods.

### Sample Output:

```
All Issues:
Bug ID: 1:Login Issue | Severity: High
Task #2:Implement Feature X | Estimated Hours: 5
Assigned To: Bob

Reporting Status of Issues:
Bug: 1 is under process, it is assigned To: Alice, Severity: High
Bug: 2 is under process, it is assigned To: Bob, the estimated hours is 5
```

## 🔧 Technologies Used

- .NET (C#)
- Object-Oriented Programming
- Console Application

## 🚀 Getting Started

To run the project:

1. Clone the repository.
2. Open the solution in Visual Studio or VS Code.
3. Build and run the project.

---

Made for training and educational purposes.
