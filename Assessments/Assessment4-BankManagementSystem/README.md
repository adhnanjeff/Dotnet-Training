# 🏦 BankPro -- Bank Management System (In-Memory)

## 📌 Overview

BankPro is a lightweight **Bank Management System** built on **.NET 8
Web API** that uses in-memory collections instead of a real database.\
It demonstrates core software engineering concepts such as:

-   Repository Pattern\
-   Service Layer & Business Logic\
-   AutoMapper for DTO mapping\
-   Dependency Injection\
-   Async/Await handling\
-   Unit Testing (xUnit + Moq)\
-   RESTful API design\
-   Interactive API docs with **Swagger**

The system manages **Customers, Accounts, and Transactions** with
business rules like account creation, money transfer, and transaction
history tracking.

------------------------------------------------------------------------

## 🎯 Objectives

-   Manage Customers and their Accounts\
-   Support money transfers between accounts with **balance
    validation**\
-   Maintain transaction history for audit and tracking\
-   Implement repository pattern with **in-memory collections**\
-   Provide Swagger-based **interactive documentation** and testing

------------------------------------------------------------------------

## ⚙️ Architecture

-   **Entities** → Customer, Account, Transaction\
-   **DTOs** → Request/Response models for API communication\
-   **Repositories** → In-memory implementations (List`<T>`{=html} as
    data store)\
-   **Services** → Business logic (validation, transfers, mapping)\
-   **AutoMapper** → DTO ↔ Entity mapping\
-   **Controllers** → RESTful APIs (Swagger exposed)\
-   **Unit Tests** → xUnit + Moq

------------------------------------------------------------------------

## 🔑 Features

### 👥 Customer Management

-   Create Customer → `POST /api/Customer`\
-   Get All Customers → `GET /api/Customer`\
-   Get Customer by ID → `GET /api/Customer/{id}`\
-   Update Customer → `PUT /api/Customer/{id}`\
-   Delete Customer → `DELETE /api/Customer/{id}`

### 💳 Account Management

-   Create Account → `POST /api/Account`\
-   Get All Accounts → `GET /api/Account`\
-   Get Account by ID → `GET /api/Account/{id}`\
-   Update Account → `PUT /api/Account/{id}`\
-   Delete Account → `DELETE /api/Account/{id}`

### 💸 Transaction Management

-   Transfer Money → `POST /api/Transaction/transfer`\
-   Get Transaction by ID → `GET /api/Transaction/{id}`\
-   Get All Transactions → `GET /api/Transaction`

------------------------------------------------------------------------

## ⚡ Async/Await Handling

All services and controllers use **async/await** to simulate
asynchronous operations (with `Task.FromResult` / `Task.CompletedTask`),
even though the data is in-memory.

------------------------------------------------------------------------

## 📖 Swagger API Examples

### 👥 Customer

**Create Customer**\
Request:

``` json
{
  "name": "Adhnan"
}
```

Response:

``` json
{
  "id": 1,
  "name": "Adhnan",
  "accounts": []
}
```

------------------------------------------------------------------------

### 💳 Account

**Create Account**\
Request:

``` json
{
  "accHolderId": 1,
  "bankBalance": 5000
}
```

Response:

``` json
{
  "id": 101,
  "bankBalance": 5000,
  "accHolder": "Adhnan",
  "transactions": []
}
```

------------------------------------------------------------------------

### 💸 Transaction

**Perform Transaction**\
Request:

``` json
{
  "fromAccId": 101,
  "toAccId": 102,
  "amount": 1500
}
```

Response:

``` json
{
  "transactionId": "8f46c91d-5d32-4b91-9f85-b4c47ff9e125",
  "fromAccId": 101,
  "toAccId": 102,
  "amount": 1500,
  "status": "Success"
}
```

**Error Case (Insufficient Balance):**

``` json
{
  "message": "Insufficient funds."
}
```

------------------------------------------------------------------------

## 🧪 Unit Testing

Implemented with **xUnit + Moq**.\
Covers: - Customer creation, update, delete\
- Account creation and update\
- Transaction logic (including insufficient funds)\
- Repository interaction validation

------------------------------------------------------------------------

## 📌 Example Flow (via Swagger)

1.  Create a Customer → `POST /api/Customer`\
2.  Create an Account for that Customer → `POST /api/Account`\
3.  Transfer Money between Accounts → `POST /api/Transaction/transfer`\
4.  Check Transaction History → `GET /api/Transaction`

------------------------------------------------------------------------

## 🚀 How to Run

1.  Clone the repository\
2.  Run the project → Swagger UI opens at
    `https://localhost:<port>/swagger`\
3.  Use Swagger UI to test all APIs

------------------------------------------------------------------------

✅ **Tech Stack**: .NET 8 Web API, AutoMapper, xUnit, Moq, Swagger UI
