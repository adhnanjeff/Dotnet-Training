# 📚 Student Course Tracker - EF Core Console App

This is a simple console-based application built with **C#** and **Entity Framework Core** that tracks students and the courses they are enrolled in.

---

## 🚀 Features

- Add new students with course selection
- View all students and their enrolled courses
- Update student details (name, age, course)
- Delete a student
- View all available courses
- Uses **SQL Server** and EF Core for data management

---

## 🛠️ Technologies Used

- C# (.NET Core)
- Entity Framework Core
- SQL Server
- LINQ
- Console UI

---

## 🗃️ Database Structure

### Tables

- **Students**
  - `StudentId` (Primary Key)
  - `StudentName`
  - `Age`
  - `CourseId` (Foreign Key)

- **Courses**
  - `CourseId` (Primary Key)
  - `CourseName`

---

## 🔄 Application Flow

1. **On Launch**:
   - Deletes all existing student and course records
   - Seeds default courses: C#, Java, Python

2. **Menu Options**:
   ```
   1. Add a Student
   2. View All Students
   3. Delete a Student
   4. Update a Student
   5. View All Courses
   6. Exit
   ```

---

## 📥 Example Usage

### ➕ Add Student

```
Enter Student Name: Alice
Enter Student Age: 22
Enter Course Id (1 for C#, 2 for Java, 3 for Python): 1
Student added successfully!
```

### 📝 Update Student

```
Enter Student Id to update: 2
Enter new Student Name (leave blank to keep current):
Enter new Age (0 to keep current): 23
Enter new Course Id (0 to keep current): 3
Student updated successfully!
```

---

## 📌 Note

- Course seeding resets every time the application is run.
- Course IDs are assumed to be 1, 2, and 3 corresponding to C#, Java, and Python.

---

## 📂 Project Structure

```
EFCoreDbPhase2/
│
├── Models/
│   ├── Student.cs
│   └── Course.cs
│
├── CourseContext.cs
├── Program.cs
└── README.md
```

---

## ✅ How to Run

1. Make sure SQL Server is running.
2. Run the application from your IDE or terminal.
3. Use the console interface to interact with the system.

---

## 👨‍💻 Author

Adhnan Jeff