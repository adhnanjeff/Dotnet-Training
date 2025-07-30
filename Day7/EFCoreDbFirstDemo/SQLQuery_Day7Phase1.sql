CREATE DATABASE CompanyDB;

USE CompanyDB;

CREATE TABLE Department (
    DeptId INT IDENTITY(1,1) PRIMARY KEY,
    DeptName NVARCHAR(100) NOT NULL
);



CREATE TABLE Employees (
    EmpId INT IDENTITY(1,1) PRIMARY KEY,  -- Now it's auto-incrementing
    EmpName NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    DeptId INT,
    FOREIGN KEY (DeptId) REFERENCES Department(DeptId)
);

INSERT INTO Department (DeptName) VALUES ('IT');

INSERT INTO Employees (EmpName, Age, DeptId)
VALUES ('Ahalya', 27, 1);

-- Select * from Employees;
 

