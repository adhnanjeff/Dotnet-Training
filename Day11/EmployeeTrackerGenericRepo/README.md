# 👨‍💼 EmployeeTrackerGenericRepo

A modular console-based application to manage **Employees** and their **Departments**, built using **clean architecture principles** and the **Generic Repository Pattern** with in-memory storage.

---

## 🎯 Goal

Design a reusable and testable .NET 6 console app to:
- Add, update, delete, and list **Employees** and **Departments**
- Maintain separation of concerns via **Onion Architecture**
- Practice applying **SOLID** principles with manual **Dependency Injection**

---

## 📦 Tech Stack

- ✅ .NET 6 Console Application  
- ✅ Onion-like Layered Architecture  
- ✅ In-Memory Generic Repository Pattern  
- ✅ Manual Dependency Injection  
- ✅ C# 10

---

## 🧱 Solution Structure

```
EmployeeTrackerGenericRepo (Solution)
│
├── EmployeeTrackerGenericRepo.Core          
│   ├── Entities
│   │   ├── Employee.cs
│   │   └── Department.cs
│   └── Interfaces
│       ├── IRepository<T>
│       ├── IEmployeeRepository
│       └── IDepartmentRepository
│
├── EmployeeTrackerGenericRepo.Infrastructure  
│   └── Repositories
│       ├── EmployeeRepository.cs
│       └── DepartmentRepository.cs
│
├── EmployeeTrackerGenericRepo.Application    
│   └── Services
│       ├── EmployeeService.cs
│       └── DepartmentService.cs
│
└── EmployeeTrackerGenericRepo.ConsoleUI      
    └── Program.cs (Console app entry point)
```

---

## 🔁 Features Implemented

### 🧑 Employee Entity
- `Id`
- `EmpName`
- `Department` (Navigation Property)

### 🏢 Department Entity
- `Id`
- `Name`

### 🛠️ Services
- `EmployeeService` and `DepartmentService`
- Perform CRUD operations via **Repositories**
- Fully decoupled from infrastructure

### 🖥️ Console UI
- Add / View / Update / Delete Employees
- Add / View / Update / Delete Departments
- Display employee details with their department
- Demonstrates end-to-end clean separation

---

## ▶️ Run the App

```bash
cd EmployeeTrackerGenericRepo.ConsoleUI
dotnet run
```

---

## 🔍 Learning Outcomes

- Implement a reusable `GenericRepository<T>` (extendable design)
- Understand **Layered Architecture** (Core, Infrastructure, Application, UI)
- Practice **SOLID** principles & interface-driven service design
- Experience how abstraction leads to testability & future-proofing (e.g., replacing in-memory repo with EF Core or SQL later)

---

## 📸 Preview

> Screenshot of console output:
![Console Output](./your_console_output_image_here.png)

---

## ✨ Credits

Developed by [Your Name]  
.NET 6 | Clean Architecture | Console Development