# 📅 Leave Management System (LMS)

A simple **console-based Leave Management System** built with C# demonstrating OOP principles such as **abstraction, inheritance, interfaces, and polymorphism**. It handles different types of leave requests (Sick Leave and Casual Leave), allows status tracking, and uses interfaces for flexible approval logic.

---

## 🚀 Features

- 📝 Submit Sick Leave or Casual Leave requests
- 🔍 Display all leave requests with detailed info
- ✅ Approve or Reject leave requests
- 👩‍💼 Interface-based approval system (`IApprovable`)
- 🧠 Clean object-oriented design with error handling

---

## 📂 Project Structure

```
Day3Proj1_LMS/
├── Models/
│   ├── LeaveRequest.cs          # Abstract base class for leave
│   ├── SickLeave.cs             # Derived class with doctor's note
│   ├── CasualLeave.cs           # Derived class with reason
│   └── IApprovable.cs           # Interface to handle approvals
├── Services/
│   ├── ILeaveService.cs         # Service contract
│   └── LeaveService.cs          # Service implementation
├── Program.cs                   # Main entry point
```

---

## 🧱 Core Classes

### `LeaveRequest` (Abstract)
- Holds common leave fields like `Id`, `EmployeeName`, `DaysRequested`, and `Status`.
- Includes methods to `Approve()`, `Reject()`, and an abstract `Display()`.

### `SickLeave` & `CasualLeave`
- Extend `LeaveRequest`.
- Implement `IApprovable` to support approval status.
- Require specific additional fields (e.g., doctor’s note, reason).

### `IApprovable` (Interface)
- Declares `ShowApprovalStatus()` for polymorphic status reporting.

### `LeaveService`
- Displays leave requests
- Displays approval statuses for all `IApprovable` implementations

---

## 🧪 Example Execution (Console Output)

```
Leave Requests:
Sick Leave Request ID: 1
Employee Name: Subashini
Days Requested: 5
Status: Pending
Doctor's Note: Scraped Knee

Sick Leave Request ID: 2
Employee Name: Jeff
Days Requested: 3
Status: Pending
Doctor's Note: Summa

Processing Leave Requests...
Sick Leave - Reason: Scraped Knee
Casual Leave - Reason: Summa

Sick Leave Request ID: 1 is currently Approved.
Sick Leave Request ID: 2 is currently Rejected.
```

---

## ✅ How It Works

1. Two leave requests (`SickLeave`, `CasualLeave`) are created.
2. All leave requests are displayed using `LeaveService`.
3. The program checks the type and casts to `IApprovable` to show approval status.
4. Leaves are either **approved** or **rejected** based on their type.
5. Updated statuses are displayed again via the service.

---

## 🛠 Technologies Used

- Language: C#
- Framework: .NET Core / .NET SDK
- IDE: Visual Studio

---

## 👨‍💻 Author

**Adhnan Jeff**  
This project was created as part of Day 3 in .NET training to demonstrate C# OOP and interface design patterns.

---

## 📌 Notes

- This is a console-based simulation. No persistent storage is used.
- Extendable for more leave types and UI enhancements.
