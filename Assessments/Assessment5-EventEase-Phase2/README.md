# 🎯 EventEase - Event Management System

## 📌 Overview
EventEase is a simple event management system built using **ASP.NET Core Web API** and a layered architecture consisting of:
- **API Layer**: Handles HTTP requests and responses.
- **Application Layer**: Contains business logic.
- **Core Layer**: Defines entities, DTOs, and interfaces.
- **Infrastructure Layer**: Implements repositories and data storage.

---

## 🛠 Project Setup

### 1️⃣ Create the Project
```bash
# Create a new solution
dotnet new sln -n Assessment3-EventEase

# Create the Web API project
dotnet new webapi -n EventEase.API

# Create the Application (Services) project
dotnet new classlib -n EventEase.Application

# Create the Core (Entities/Interfaces/DTOs) project
dotnet new classlib -n EventEase.Core

# Create the Infrastructure (Repositories) project
dotnet new classlib -n EventEase.Infrastructure
```

---

### 2️⃣ File Structure
```bash
Assessments/
│
├── Assessment3-EventEase.sln
│
├── EventEase.API/               # API Layer
│   ├── Controllers/
│   │   ├── ReistratisController.cs
│   │   ├── EventController.cs
│   │   └── UserController.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── EventManagementSystem.API.csproj
│
├── EventEase.Core/              # Core Layer
│   ├── DTOs/
│   │   ├── RegistrationResponseDTO.cs
│   │   ├── EventRequestDTO.cs
│   │   ├── EventResponseDTO.cs
│   │   ├── UserResponseDTO.cs
│   │   ├── UserRequestDTO.cs
│   ├── Entities/
│   │   ├── Registration.cs
│   │   ├── Event.cs
│   │   ├── User.cs
│   ├── Interfaces/
│   │   ├── IEventRepository.cs
│   │   ├── IUserRepository.cs
│   └── EventEase.Core.csproj
│
├── EventEase.Infrastructure/    # Infrastructure Layer
│   ├── Repositories/
│   │   ├── EventRepository.cs
│   │   ├── UserRepository.cs
│   │   ├── RegistrationRepository.cs
│   └── EventEase.Infrastructure.csproj

```

---

### 3️⃣ Add Project References
```bash
# Add Core to API
dotnet add EventEase.API/EventEase.API.csproj reference EventEase.Core/EventEase.Core.csproj

# Add Infrastructure to API
dotnet add EventEase.API/EventEase.API.csproj reference EventEase.Infrastructure/EventEase.Infrastructure.csproj

# Add Core to Infrastructure
dotnet add EventEase.Infrastructure/EventEase.Infrastructure.csproj reference EventEase.Core/EventEase.Core.csproj

# Add Application References
dotnet add EventEase.API/EventEase.API.csproj reference EventEase.Application/EventEase.Application.csproj
dotnet add EventEase.Application/EventEase.Application.csproj reference EventEase.Core/EventEase.Core.csproj
dotnet add EventEase.Application/EventEase.Application.csproj reference EventEase.Infrastructure/EventEase.Infrastructure.csproj
```

---

### 4️⃣ Run the Application
```bash
dotnet run --project EventEase.API
```
Access Swagger UI at:
```
https://localhost:{port}/swagger
```

---

## 📍 API Endpoints & Outputs

### 1. **Get User by ID**
**Endpoint:**  
`GET /User/{id}`  

**Output:**  

<img width="1186" height="771" alt="image" src="https://github.com/user-attachments/assets/61ddc679-f222-4935-b0d5-2fb8a4426261" />


---

### 2. **Get All Users**
**Endpoint:**  
`GET /User`  

**Output:**  

<img width="1175" height="605" alt="image" src="https://github.com/user-attachments/assets/d107489e-3161-489e-abbb-fb395f75bf46" />
```

---

### 3. **Get Event by ID**
**Endpoint:**  
`GET /Event/{id}`  

**Output:**  

<img width="1191" height="860" alt="image" src="https://github.com/user-attachments/assets/66b6d8c9-9ef3-45c7-b968-36d473a535d7" />

```

---

### 4. **Get All Events**
**Endpoint:**  
`GET /Event`  

**Output:**  

<img width="1745" height="652" alt="image" src="https://github.com/user-attachments/assets/123badac-9db5-477f-8b78-89bfd4f80a83" />


---

### 5. **Get Users by Event ID**
**Endpoint:**  
`GET /Registration/event/{eventId}`  

**Output:**  

<img width="1187" height="901" alt="image" src="https://github.com/user-attachments/assets/fdf56a2b-331c-4602-9d66-c47704107462" />

---

### 6. **Get All Registrations**
**Endpoint:**  
`GET /Registration/all-events-with-users`  

**Output:**  

<img width="1185" height="433" alt="image" src="https://github.com/user-attachments/assets/33109f50-3758-4e1f-ae86-d4121ae931e3" />

<img width="1197" height="554" alt="image" src="https://github.com/user-attachments/assets/2413c566-faf7-4a96-a5c9-5c02b1a34b27" />


---

## 🔗 Git Commands
```bash
git add .
git commit -m "Initial commit - Event Management System"
git push origin main
```

---

## 📌 Technologies Used
- **C#**
- **ASP.NET Core Web API**
- **Swagger**
- **Layered Architecture**
