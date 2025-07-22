# 🛠️ Ticket Request Management System - Phase 2

This project builds upon Phase 1 by introducing **Agent-based ticket assignment and resolution**. It simulates a request system where agents assign and resolve requests with a trackable resolution time.

## 📁 Project Structure

```
Day1Proj2/
├── Models/
│   ├── Agent.cs
│   └── Request.cs
├── Program.cs
```

## 🚀 Features

- Create agents with unique roles.
- Create and assign requests between agents.
- Reassign requests to another agent.
- Track request status (`Not Resolved` → `Resolved`).
- Track `Resolution Time` (in hours).
- Prevent reassignment if the request is already resolved.

## 📄 Class Overview

### 🔹 `Agent`
Represents the support personnel handling requests.
- Properties: `AgentId`, `AgentName`, `AgentRole`
- Method: `DisplayAgent()`

### 🔹 `Request`
Represents an issue or service request.
- Properties: `RequestId`, `RequestDescription`, `CreatedOn`, `ResolutionTime`, `IsClosed`, `AssignedBy`, `AssignedTo`
- Methods:
  - `ResolveRequest()`: Marks request as resolved and calculates time.
  - `ReassignRequest()`: Allows reassignment only if not closed.
  - `DisplayRequest()`: Shows request details.

## 🧪 Sample Output

```
----- Request Summary Before Reassignment -----
RequestId: 101
Description: Unable to login with valid credentials
Status: Not Resolved
...
----- Reassigning Requests -----
...
----- Request Summary After Closing -----
RequestId: 101
Status: Resolved
Resolution Time (in hours): 0.0003
...
```

## 📝 Author

Adhnan Jeff