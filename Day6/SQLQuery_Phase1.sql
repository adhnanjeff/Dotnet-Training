CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,       -- Auto-incrementing primary key
    FullName NVARCHAR(100) NOT NULL,            -- Required full name
    Email NVARCHAR(100) NOT NULL UNIQUE,        -- Required and unique email
    UserRole NVARCHAR(50) NOT NULL                  -- Required role
);

CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,     -- Auto-incrementing primary key
    ProjectName NVARCHAR(100) NOT NULL,          -- Required project name
    StartDate DATE NOT NULL,                     -- Required start date
    EndDate DATE NOT NULL                        -- Required end date
);


CREATE TABLE Status (
    StatusID INT IDENTITY(1,1) PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL
);

CREATE TABLE Bugs (
    BugID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    BugDesc NVARCHAR(MAX),  -- Optional long text
    CreatedDate DATETIME DEFAULT GETDATE(), -- Current date and time
    Priority NVARCHAR(20),
    ProjectID INT NOT NULL,
    AssignedTo INT NOT NULL,
    StatusID INT NOT NULL,

    -- Foreign key constraints
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID),
    FOREIGN KEY (AssignedTo) REFERENCES Users(UserID),
    FOREIGN KEY (StatusID) REFERENCES Status(StatusID)
);

SELECT * FROM INFORMATION_SCHEMA.TABLES;