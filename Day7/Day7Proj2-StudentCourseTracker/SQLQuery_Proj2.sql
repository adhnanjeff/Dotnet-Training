-- CREATE DATABASE CourseDB;

-- USE CourseDB;

-- CREATE TABLE Course (
--     CourseId INT IDENTITY(1,1) PRIMARY KEY,
--     CourseName VARCHAR(50) NOT NULL
-- );

CREATE TABLE Student (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentName VARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    CourseId INT,

    FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
);

