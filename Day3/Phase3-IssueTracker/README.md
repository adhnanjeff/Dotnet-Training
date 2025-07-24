
# 📌 Phase 3 - Issue Tracker (OOP Concepts & Interface-Based Design)

## 📁 Project Structure

```
Phase3_IssueTracker/
│
├── Models/
│   ├── Issue.cs
│   ├── Bug.cs
│   ├── Task.cs
│   ├── FeatureRequest.cs
│   └── IReportable.cs
│
├── Services/
│   ├── ITrackerService.cs
│   └── TrackerService.cs
│
├── Program.cs
```

## ✅ Objective

To demonstrate advanced object-oriented programming concepts in C# by building an **Issue Tracker System** using:

- Abstract Classes
- Interfaces (`IReportable`)
- Polymorphism and Inheritance
- List-based Data Management
- Separation of Concerns via Service Layer

---

## 🧱 Class Breakdown

### 🔹 `Issue` (Abstract Class)
- Base class for all issue types.
- Properties: `Id`, `Title`, `AssignedTo`, `Status`
- Methods: `Close()`, `Display()` (abstract)

---

### 🔹 `Bug`, `Task`, `FeatureRequest` (Derived Classes)
All inherit from `Issue` and implement `IReportable`:

- `Bug` includes a `Severity` level.
- `Task` includes `EstimatedHours`.
- `FeatureRequest` includes `RequestedBy` and `Date`.

Each implements:
- `ReportStatus()`: prints current working status.
- `getSummary()`: prints issue summary.
- Overrides `Display()` method.

---

### 🔹 `IReportable` (Interface)
- Enforces `ReportStatus()` and `getSummary()` methods for reportable issues.

---

### 🔹 `ITrackerService` & `TrackerService` (Service Layer)
- `DisplayAllIssues(List<Issue>)`: Shows all details.
- `DisplayIssueSummary(List<IReportable>)`: Summary view.
- `ShowReportStatus(List<IReportable>)`: Shows live status updates.

---

## 🏁 Execution Flow (`Program.cs`)

1. Create multiple issues (`Task`, `Bug`, `FeatureRequest`).
2. Add them to:
   - `List<Issue>` for general tracking.
   - `List<IReportable>` for reporting operations.
3. Call:
   - `DisplayAllIssues()`
   - Update some statuses (`Close()`)
   - `DisplayIssueSummary()`
   - `ShowReportStatus()`

---

## 🧪 Sample Output

```
Displaying all issues...

Task #1: Implement Login Feature | Estimated Hours: 5
Assigned To: Alice
Status: Open

Bug ID: 2:Fix Null Reference Exception | Severity: High
Status: Open

Feature Request ID: 3:Add Dark Mode | Requested By: Dave, Expected Release Date: 2023-12-31
Assigned To: Charlie
Status: Open

Displaying issue summary...
Task Summary: ID=1, Title=Implement Login Feature, AssignedTo=Alice, EstimatedHours=5
Bug Summary: ID=2, Title=Fix Null Reference Exception, AssignedTo=Bob, Severity=High
Feature Request Summary: ID=3, Title=Add Dark Mode, AssignedTo=Charlie, RequestedBy=Dave, Expected Release Date=2023-12-31

Reporting status of issues...
Task: 1 is under process, it is assigned To: Alice, the estimated hours is 5

Bug: 2 is under process, it is assigned To: Bob, Severity: High

Feature Request: 3 is under process, it is assigned To: Charlie, Requested By: Dave, Expected Release Date: 2023-12-31
```

---

## 📘 Learnings

- Leveraged interface-based programming to decouple logic.
- Practiced polymorphism using shared interface methods.
- Organized code into meaningful layers (models vs services).
- Used collection (`List<T>`) polymorphism with base class and interface.

---

## 🛠️ Technologies

- Language: **C#**
- Platform: **.NET Core**
- Editor: **Visual Studio**

---

## 📅 Phase Reference

- **Phase 1**: Basic Leave Tracker using inheritance
- **Phase 2**: Enhanced Leave Tracker with Interface & Service
- ✅ **Phase 3**: Issue Tracker using Interface + Abstract Class + Full Service Layer

---
