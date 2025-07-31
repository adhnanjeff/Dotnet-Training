-- CREATE DATABASE SupportDeskDB;
-- USE SupportDeskDB;

-- CREATE TABLE Users(
--     UserId INT IDENTITY(1,1) PRIMARY KEY,
--     UserName NVARCHAR(50) NOT NULL,
--     Role NVARCHAR(50) NOT NULL
-- );

-- CREATE TABLE Tickets(
--     TicketId INT IDENTITY(1,1) PRIMARY KEY,
--     Title NVARCHAR(200) NOT NULL,
--     UserId INT,
--     FOREIGN KEY (UserId) REFERENCES Users(UserId)
-- );

-- CREATE TABLE Tags(
--     TagId INT IDENTITY(1,1) PRIMARY KEY,
--     TagName NVARCHAR(100) NOT NULL
-- );

-- CREATE TABLE TicketTags (
--     TicketId INT NOT NULL,
--     TagId INT NOT NULL,
--     PRIMARY KEY (TicketId, TagId),
--     FOREIGN KEY (TicketId) REFERENCES Tickets(TicketId) ON DELETE CASCADE,
--     FOREIGN KEY (TagId) REFERENCES Tags(TagId) ON DELETE CASCADE
-- );

-- CREATE TABLE Department(
--     DeptId INT IDENTITY(1,1) PRIMARY KEY,
--     DeptName NVARCHAR(50) NOT NULL
-- );

-- CREATE TABLE TicketHistory(
--     HistoryId INT IDENTITY(1,1) PRIMARY KEY,
--     TicketId INT,
--     TicketDesc NVARCHAR(100) NOT NULL,
--     TimeStamp DATETIME,
--     FOREIGN KEY (TicketId) REFERENCES Tickets(TicketId) ON DELETE CASCADE
-- );

-- CREATE TABLE CustomerProfile(
--     CustomerId INT PRIMARY KEY,
--     Address NVARCHAR(50) NOT NULL,
--     Phone NVARCHAR(50) NOT NULL,
--     FOREIGN KEY (CustomerId) REFERENCES Users(UserId) ON DELETE CASCADE
-- );


-- ALTER TABLE Tickets
-- ADD AssignedToId INT NULL;

-- ALTER TABLE Tickets
-- ADD CONSTRAINT FK_Tickets_AssignedTo
--     FOREIGN KEY (AssignedToId) REFERENCES Users(UserId);

