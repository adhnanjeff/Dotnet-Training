CREATE DATABASE BugTrackerDB;


USE BugTrackerDB;

Create Users Table
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Role NVARCHAR(50) NOT NULL
);


Create Projects Table
CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectName NVARCHAR(100) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);


-- Create Status Table
CREATE TABLE Status (
    StatusID INT IDENTITY(1,1) PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL
);


-- Create Bugs Table
CREATE TABLE Bugs (
    BugID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    BugDesc NVARCHAR(MAX),
    CreatedDate DATETIME DEFAULT GETDATE(),
    Priority NVARCHAR(10) CHECK (Priority IN ('Low', 'Medium', 'High')),
    ProjectID INT,
    AssignedTo INT,
    StatusID INT,
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID),
    FOREIGN KEY (AssignedTo) REFERENCES Users(UserID),
    FOREIGN KEY (StatusID) REFERENCES Status(StatusID)
);


INSERT INTO Users (FullName, Email, Role) VALUES
('Adhnan Jeff', 'adhnan.jeff@example.com', 'Developer'),
('Subashini Mathi', 'subashini.mathi@example.com', 'Manager'),
('Amrith Bharath', 'amrith.bharath@example.com', 'Developer'),
('Abhinavu G', 'abhinavu.g@example.com', 'Tester');

INSERT INTO Projects (ProjectName, StartDate, EndDate) VALUES
('Travel Manager', '2024-01-01', '2024-06-01'),
('E-Commerce System', '2024-03-15', '2024-09-15'),
('Hospital Management System', '2024-05-01', '2024-12-15'),
('Online Exam Portal', '2024-06-10', '2024-11-20');

SELECT * FROM Projects;

INSERT INTO Status (StatusName) VALUES
('New'),
('In Progress'),
('Resolved'),
('Closed');

INSERT INTO Bugs (Title, BugDesc, Priority, ProjectID, AssignedTo, StatusID)
VALUES
('Login Button Not Responding', 'Clicking login doesn’t redirect to dashboard', 'High', 9, 1, 1),
('Cart Quantity Not Updating', 'Product quantity not reflected in cart', 'Medium', 9, 2, 2),
('Broken Footer Link', 'Privacy policy link broken on homepage', 'Low', 10, 4, 1),
('Payment Failure', 'Payment gateway fails intermittently', 'High', 12, 1, 3);

SELECT * FROM Bugs;

-- View all bugs with JOINs to see related names
SELECT 
    B.BugID, B.Title, B.Priority, 
    P.ProjectName, 
    U.FullName AS AssignedTo,
    S.StatusName, 
    B.CreatedDate
FROM Bugs B
JOIN Projects P ON B.ProjectID = P.ProjectID
JOIN Users U ON B.AssignedTo = U.UserID
JOIN Status S ON B.StatusID = S.StatusID;
