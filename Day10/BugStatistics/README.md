# 🐞 BugDashboardStats

A layered, LINQ-powered **console application** for analyzing, filtering, and reporting software bug data. Built to simulate a real-world bug tracker dashboard using clean architecture principles in C#.

---

## 📌 Project Overview

`BugDashboardStats` provides a flexible and extensible command-line interface to:

- Filter bugs by status, priority, or project
- Sort bugs by date, priority, or assigned user
- View grouped statistics for dashboards
- Practice LINQ queries and DTO usage in a clean, modular architecture

---

## 📁 Folder Structure

```
BugDashboardStats/
├── Core/
│   └── Entities/              # Domain models (Bug, Project, User)
├── Repositories/
│   └── BugRepository.cs       # Data access and seeding
├── Services/
│   └── BugService.cs          # Business logic and LINQ operations
├── DTOs/
│   ├── BugDTO.cs              # Lightweight bug presentation model
│   └── GroupStatsDTO.cs       # Grouping/aggregation result model
├── UI/
│   └── Program.cs             # Console menu and user interface
```

---

## 🎯 Project Phases

### ✅ Phase 1 – Filtering and Sorting

**Features:**

- Filter bugs by:
  - ✅ Status (`Open`, `Closed`, `In Progress`)
  - ✅ Priority (`High`, `Medium`, `Low`)
  - ✅ Project name
- Sort bugs by:
  - 📅 Created Date
  - 🔼 Priority
  - 👤 Assigned User
- Display bugs in clean tabular format

**LINQ Concepts:**

- `Where()`, `OrderBy()`, `ThenByDescending()`
- Projection to `BugDTO`

---

### ✅ Phase 2 – Dashboard Grouping & Aggregation

**Features:**

- Group bugs by:
  - 🧱 Project
  - 🎯 Priority
  - 📊 Status
- View grouped bug counts
- Display results in summarized dashboard format

**LINQ Concepts:**

- `GroupBy()`, `Select()`
- `Count()`, anonymous projections
- Nested aggregations

---

## 🧪 Sample Menu UI

```text
--- Bug Dashboard Menu ---
1. View All Bugs
2. Filter Bugs
3. Sort Bugs
4. Show Grouped Stats
5. Exit
```

---

## 🧠 Sample Output

```
Title                    Status       Priority Project      Assigned To         Created Date
------------------------------------------------------------------------------------------
Crash on login           Open         High     AlphaApp     Alice Johnson       01/08/2025
UI overlap issue         In Progress  Low      AlphaApp     Bob Smith           30/07/2025
Database error           Closed       High     BetaSite     Alice Johnson       03/08/2025
Typo in footer           Open         Low      BetaSite     Bob Smith           02/08/2025
```

---

## 🛠️ Tech Stack

- **Language:** C# (.NET 6/7)
- **Type:** Console Application
- **Concepts Used:**
  - Object-Oriented Design
  - DTOs and Projections
  - Layered Architecture (Core → Repo → Service → UI)
  - Advanced LINQ queries

---

## 📈 Learning Goals

- Practice **LINQ filtering, sorting, grouping**
- Clean architecture and separation of concerns
- Use of DTOs to protect core domain models
- Console UI formatting and user interaction

---

## 📃 License

This project is open-source and available for personal or educational use.

---

## 🙌 Contributions

Pull requests and suggestions are welcome! Feel free to fork this repository and contribute with new filtering modes, database persistence, or a fancy UI.

---

## 💡 Future Enhancements

- [ ] Export to CSV/JSON
- [ ] Load data from EF Core / SQLite
- [ ] Add Severity, Module columns
- [ ] Integrate with Spectre.Console for fancy terminal UI

---