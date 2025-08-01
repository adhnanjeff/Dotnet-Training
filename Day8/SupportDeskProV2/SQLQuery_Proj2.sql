-- ================================================
-- 📦 Support Desk Database Schema - Full SQL File
-- ================================================
-- CREATE DATABASE SupportDeskPro;

-- USE SupportDeskPro;
-- 1. USERS
-- CREATE TABLE Users (
--     UserId INT PRIMARY KEY IDENTITY,
--     UserName NVARCHAR(100) NOT NULL,
--     Email NVARCHAR(100) NOT NULL,
--     Role NVARCHAR(20) NOT NULL, -- 'Customer' or 'SupportAgent'
--     DepartmentId INT NULL       -- FK to Departments (for agents)
-- );

-- -- 2. CUSTOMER PROFILES (1-1 with Users)
-- CREATE TABLE CustomerProfiles (
--     UserId INT PRIMARY KEY, -- Also FK to Users
--     Address NVARCHAR(255),
--     Phone NVARCHAR(20),
--     FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
-- );

-- -- 3. DEPARTMENTS
-- CREATE TABLE Departments (
--     DepartmentId INT PRIMARY KEY IDENTITY,
--     DepartmentName NVARCHAR(100) NOT NULL
-- );

-- -- FK: Users.DepartmentId → Departments
-- ALTER TABLE Users
-- ADD CONSTRAINT FK_Users_Department
--     FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId);

-- -- 4. CATEGORIES
-- CREATE TABLE Categories (
--     CategoryId INT PRIMARY KEY IDENTITY,
--     CategoryName NVARCHAR(100) NOT NULL
-- );

-- -- 5. TICKETS
-- CREATE TABLE Tickets (
--     TicketId INT PRIMARY KEY IDENTITY,
--     Title NVARCHAR(200) NOT NULL,
--     Description NVARCHAR(MAX),
--     CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
--     Status NVARCHAR(50) NOT NULL,
--     CustomerId INT NOT NULL,
--     CategoryId INT NOT NULL,

--     FOREIGN KEY (CustomerId) REFERENCES Users(UserId) ON DELETE CASCADE,
--     FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
-- );

-- 6. TICKET ↔ SUPPORTAGENT (M-M)
-- CREATE TABLE TicketAssignments (
--     TicketId INT NOT NULL,
--     SupportAgentId INT NOT NULL,
--     PRIMARY KEY (TicketId, SupportAgentId),
--     FOREIGN KEY (TicketId) REFERENCES Tickets(TicketId) ON DELETE CASCADE,
--     FOREIGN KEY (SupportAgentId) REFERENCES Users(UserId) 
-- );

-- -- 7. TICKET HISTORY (1-M with Tickets)
-- CREATE TABLE TicketHistories (
--     TicketHistoryId INT PRIMARY KEY IDENTITY,
--     TicketId INT NOT NULL,
--     Action NVARCHAR(500),
--     TimeStamp DATETIME NOT NULL DEFAULT GETDATE(),

--     FOREIGN KEY (TicketId) REFERENCES Tickets(TicketId) ON DELETE CASCADE
-- );

-- ✅ All tables and relationships created successfully.
