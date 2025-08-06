-- DROP DATABASE IF EXISTS SupportDeskPro;
CREATE DATABASE SupportDeskPro;

USE SupportDeskPro;

-- Table: Users (Base Table)
DROP TABLE Users;
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);

-- Table: Customers (Extends Users)
CREATE TABLE Customers (
    Id INT PRIMARY KEY,
    FOREIGN KEY (Id) REFERENCES Users(Id)
);

-- Table: SupportAgents (Extends Users)
DROP TABLE SupportAgents;
CREATE TABLE SupportAgents (
    Id INT PRIMARY KEY,
    DepartmentId INT NULL,
    FOREIGN KEY (Id) REFERENCES Users(Id),
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

-- Table: Departments
DROP TABLE Departments;
CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL
);

-- Table: CustomerProfiles (1-1 with Customers)
CREATE TABLE CustomerProfiles (
    Id INT PRIMARY KEY,
    Address NVARCHAR(200),
    Phone NVARCHAR(20),
    FOREIGN KEY (Id) REFERENCES Customers(Id)
);

-- Table: Categories
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL
);

-- Table: Tickets
CREATE TABLE Tickets (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(50),
    CustomerId INT NOT NULL,
    CategoryId INT NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Table: TicketHistories (1-M with Tickets)
CREATE TABLE TicketHistories (
    Id INT PRIMARY KEY IDENTITY,
    TicketId INT NOT NULL,
    ActionTaken NVARCHAR(200),
    Timestamp DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (TicketId) REFERENCES Tickets(Id) ON DELETE CASCADE
);

-- Table: TicketSupportAgent (Join table for M-M)
CREATE TABLE TicketSupportAgent (
    TicketId INT NOT NULL,
    SupportAgentId INT NOT NULL,
    PRIMARY KEY (TicketId, SupportAgentId),
    FOREIGN KEY (TicketId) REFERENCES Tickets(Id),
    FOREIGN KEY (SupportAgentId) REFERENCES SupportAgents(Id)
);

SELECT * FROM Tickets;