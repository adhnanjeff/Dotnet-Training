# EFCoreDbPhase2 – Employee & Department Management Console App

A simple .NET Core console application demonstrating **Entity Framework Core (EF Core)** concepts like:
- Code-first approach
- Auto-generated keys with reseeding
- One-to-many relationships (Department ↔ Employees)
- Basic CRUD operations
- Displaying relational data using `Include()`

---

## 🏗️ Project Structure

```
EFCoreDbPhase2/
├── Models/
│   ├── Department.cs
│   └── Employee.cs
├── CompanyContext.cs
└── Program.cs
```

---

## 🧠 Features

- Automatically **clears old records** from the database.
- **Resets identity seeds** for primary key columns (`EmpId`, `DeptId`) using `DBCC CHECKIDENT`.
- Adds 3 predefined departments: `IT`, `HR`, `Sales`.
- Adds 3 employees with age `21`, each linked to a different department.
- Displays all employees along with their associated department using `Include()`.

---

## 🚀 How to Run

1. Ensure you have:
   - [.NET 6 or later SDK](https://dotnet.microsoft.com/download)
   - A SQL Server instance running (local or remote)

2. Update the connection string in `CompanyContext.cs` to match your SQL Server setup.

3. Open terminal in the project directory and run:

```bash
dotnet build
dotnet run
```

---

## 🗃️ Sample Output

```
----- Departments Added -----
Id: 1, Department: IT
Id: 2, Department: HR
Id: 3, Department: Sales

Employees added successfully!

----- All Employees with Department Info -----
Id: 1, Employee: Ahalya, Age: 21, Department: HR
Id: 2, Employee: Amrith, Age: 21, Department: IT
Id: 3, Employee: Bhavya, Age: 21, Department: Sales
```

---

## 🧹 Resetting Identity Columns

The app uses raw SQL commands to reset identity values:

```csharp
context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Employees', RESEED, 0)");
context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Department', RESEED, 0)");
```

This ensures fresh IDs start from `1` after every run.

---

## 🧾 Dependencies

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`

---

## 📚 Learning Outcomes

- Working with EF Core in a real-world scenario
- Managing one-to-many relationships
- Executing raw SQL within EF Core
- Building small yet complete database-driven applications

---

## 🔧 Future Enhancements

- Add update/delete operations
- Add user input support
- Connect to a front-end interface (e.g., Blazor or ASP.NET MVC)
- Use migrations instead of manual DB creation

---

## 📄 License

This project is for educational purposes only.
