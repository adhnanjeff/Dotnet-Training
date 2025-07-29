INSERT INTO Users (FullName, Email, UserRole)
VALUES 
    ('Adhnan Jeff', 'adhnan.jeff@example.com', 'Developer'),
    ('Subashini Mathi', 'subashini.mathi@example.com', 'Tester'),
    ('Amrith Bharath', 'amrith.bharath@example.com', 'Manager'),
    ('Abhinavu G', 'abhinavu.g@example.com', 'Developer');

SELECT * FROM Users;

INSERT INTO Projects (ProjectName, StartDate, EndDate)
VALUES 
    ('Student Attendance System', '2025-01-01', '2025-05-30'),
    ('Healthcare Monitoring App', '2025-02-15', '2025-08-15'),
    ('Smart Traffic Management', '2025-03-10', '2025-10-15'),  -- ongoing
    ('Smart Traffic Management', '2025-03-10', '2025-10-15');  -- ongoing

SELECT * FROM Projects;

INSERT INTO Status (StatusName)
VALUES 
    ('New'),
    ('In Progress'),
    ('Resolved'),
    ('Closed');

SELECT * FROM Status;


INSERT INTO Bugs (Title, BugDesc, Priority, ProjectID, AssignedTo, StatusID)
VALUES 
    (
        'Face recognition login fails randomly',
        'Inconsistent login failures using face recognition in the Student Attendance System.',
        'High',
        10,  -- Student Attendance
        1,  -- Adhnan Jeff
        1   -- New
    ),
    (
        'App crashes on heart rate spike',
        'App crashes when heart rate data spikes above threshold.',
        'High',
        11,  -- Healthcare App
        2,  -- Subashini Mathi
        2   -- In Progress
    ),
    (
        'Traffic signal timer not syncing',
        'Signal countdown not synchronized across lanes in Smart Traffic System.',
        'Medium',
        12,  -- Traffic Management
        4,  -- Abhinavu G
        1   -- New
    ),
    (
        'Export attendance as PDF not working',
        'Clicking export does not generate or download PDF in Student Attendance System.',
        'Low',
        13,  -- Student Attendance
        3,  -- Amrith Bharath
        3   -- Resolved
    );


SELECT * FROM Bugs;