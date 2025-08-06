# 🧑‍💼 EmployeeTrackerMapper

A modular and layered C# console application designed to manage employees and departments using **Generic Repository Pattern**, **AutoMapper**, and **DTO-based architecture**.

---

## 📦 Project Structure

This solution is divided into **4 key projects**, each with a single responsibility:

EmployeeTrackerMapper
│
├── EmployeeTrackerMapper.Core # DTOs, Entities, Interfaces (Business Contracts)
│
├── EmployeeTrackerMapper.Infrastructure# Repository Implementations (Data Access Layer)
│
├── EmployeeTrackerMapper.Application # Services, Mappings, Application Logic
│
└── EmployeeTrackerMapper.ConsoleUI # Console-based User Interface (Presentation Layer)

yaml
Copy
Edit

---

## ✅ Features

- ✨ Clean separation of concerns (Core, Infrastructure, Application, UI)
- 🧠 Uses **AutoMapper** for DTO ↔ Entity conversions
- 💡 Implements **Generic Repository Pattern**
- 📚 Clear layering: Core, Infrastructure, Application, UI
- 🔄 Supports CRUD operations on `Employee` and `Department`
- 📦 Easily extensible for future API or Web integrations

---

## 📁 Folder Breakdown

### 1. 🧠 Core
Contains:
- **DTOs**: `EmployeeRequestDTO`, `EmployeeResponseDTO`, etc.
- **Entities**: `Employee`, `Department`
- **Interfaces**: `IEmployeeService`, `IDepartmentRepository`, etc.

### 2. 🧱 Infrastructure
Handles:
- **Repositories**: `EmployeeRepository`, `DepartmentRepository` (EF/Core or in-memory logic)
- Data interaction and persistence logic

### 3. 🚀 Application
Contains:
- **Services**: `EmployeeService`, `DepartmentService` implementing business logic
- **Mapping**: `MappingProfile.cs` for AutoMapper configuration

### 4. 🖥️ ConsoleUI
Contains:
- `Program.cs`: CLI-driven user interface
- Handles input/output logic and invokes services

---

## 🧩 Technologies Used

| Tech                | Purpose                         |
|---------------------|----------------------------------|
| C# / .NET Console   | Application Logic & UI          |
| AutoMapper          | DTO ↔ Entity Mapping            |
| Repository Pattern  | Data abstraction                |
| Layered Architecture| Clean, testable project design  |
| SOLID Principles    | Maintainability and extensibility|

---

## 🔧 How to Run

1. **Clone the Repository**

   ```bash
   git clone https://github.com/adhnanjeff/DotnetTraining.git
   cd EmployeeTrackerMapper
Open the solution in Visual Studio

Set EmployeeTrackerMapper.ConsoleUI as Startup Project

Build and Run

Use Ctrl + F5 or terminal:

```bash

dotnet run --project EmployeeTrackerMapper.ConsoleUI
🧪 Sample Functionalities
Add, Update, View Employees

Assign Departments

View Department List

Mapping between DTO and Entity via AutoMapper

Safe handling of nulls and object validation

🌐 AutoMapper Configuration
Located in:

csharp
Copy
Edit
EmployeeTrackerMapper.Application/Mapping/MappingProfile.cs
Make sure to configure all necessary mappings, for example:

csharp
Copy
Edit
CreateMap<Employee, EmployeeResponseDTO>();
CreateMap<EmployeeResponseDTO, EmployeeRequestDTO>();
CreateMap<EmployeeRequestDTO, Employee>();
📌 Future Enhancements
✅ Add Unit Tests (xUnit/NUnit)

🌐 Convert to Web API (ASP.NET Core)

💾 Connect to real database using EF Core

🔒 Implement Authentication/Authorization

🧑‍💻 Author
Adhnan Jeff
GitHub

📄 License
This project is licensed under the MIT License. See LICENSE for details.