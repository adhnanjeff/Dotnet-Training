-- CREATE DATABASE OnionSupportDeskDB;


-- USE OnionSupportDeskDB;


-- CREATE TABLE Users(
--     UserId INT IDENTITY(1,1) PRIMARY KEY,
--     UserName NVARCHAR(50) NOT NULL
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

-- ALTER TABLE Tickets ADD Status NVARCHAR(50) NOT NULL DEFAULT 'Open';
-- ALTER TABLE Tickets ADD Priority INT NOT NULL DEFAULT 1;

SELECT * FROM Users;
SELECT * FROM Tags;
SELECT * FROM Tickets;
SELECT * FROM TicketTags;




