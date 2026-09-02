-- CS107.3 Student Management System (LMS)
-- Shared Database Initialization Script for SQL Server / LocalDB

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'StudentDB')
BEGIN
    CREATE DATABASE StudentDB;
END
GO

USE StudentDB;
GO

-- 1. Create Courses Table (Member 3 - Course Management Module)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Courses')
BEGIN
    CREATE TABLE Courses (
        CourseID INT IDENTITY(1,1) PRIMARY KEY,
        CourseCode VARCHAR(20) NOT NULL UNIQUE,
        CourseName VARCHAR(150) NOT NULL,
        Credits INT NOT NULL CONSTRAINT CHK_Credits CHECK (Credits BETWEEN 1 AND 10),
        Department VARCHAR(100) NULL,
        AssignedTeacherID INT NULL,
        IsActive BIT NOT NULL DEFAULT 1,
        CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- 2. Create Students Table (Member 2 - Student Records Module)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Students')
BEGIN
    CREATE TABLE Students (
        StudentID INT IDENTITY(1,1) PRIMARY KEY,
        RegNumber VARCHAR(30) NOT NULL UNIQUE,
        FirstName VARCHAR(100) NOT NULL,
        LastName VARCHAR(100) NOT NULL,
        Email VARCHAR(150) NOT NULL,
        Phone VARCHAR(30) NULL,
        Address NVARCHAR(255) NULL,
        DateOfBirth DATE NOT NULL,
        EnrollmentDate DATETIME NOT NULL DEFAULT GETDATE(),
        IsActive BIT NOT NULL DEFAULT 1
    );
END
GO

-- 3. Create StudentCourses Junction / Enrollment Table (Shared Enrollment Relationship)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'StudentCourses')
BEGIN
    CREATE TABLE StudentCourses (
        EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
        StudentID INT NOT NULL CONSTRAINT FK_StudentCourses_Students REFERENCES Students(StudentID),
        CourseID INT NOT NULL CONSTRAINT FK_StudentCourses_Courses REFERENCES Courses(CourseID),
        EnrollmentDate DATETIME NOT NULL DEFAULT GETDATE(),
        Status VARCHAR(20) NOT NULL DEFAULT 'Enrolled',
        CONSTRAINT UQ_Student_Course UNIQUE (StudentID, CourseID)
    );
END
GO

-- Seed Sample Courses
IF NOT EXISTS (SELECT * FROM Courses WHERE CourseCode = 'CS107.3')
BEGIN
    INSERT INTO Courses (CourseCode, CourseName, Credits, Department)
    VALUES 
    ('CS107.3', 'Object Oriented Programming with C#', 3, 'Faculty of Computing'),
    ('CS101.1', 'Introduction to Computer Science', 3, 'Faculty of Computing'),
    ('SE202.2', 'Software Architecture & Design', 4, 'Faculty of Computing');
END
GO

-- Seed Sample Students
IF NOT EXISTS (SELECT * FROM Students WHERE RegNumber = 'STU/2026/001')
BEGIN
    INSERT INTO Students (RegNumber, FirstName, LastName, Email, Phone, Address, DateOfBirth)
    VALUES 
    ('STU/2026/001', 'John', 'Doe', 'john.doe@student.nsbm.ac.lk', '+94771234567', 'Colombo, Sri Lanka', '2003-05-15'),
    ('STU/2026/002', 'Jane', 'Smith', 'jane.smith@student.nsbm.ac.lk', '+94779876543', 'Kandy, Sri Lanka', '2003-08-22');
END
GO

-- Seed Sample Course Enrollments
IF NOT EXISTS (SELECT * FROM StudentCourses)
BEGIN
    INSERT INTO StudentCourses (StudentID, CourseID, Status)
    VALUES 
    (1, 1, 'Enrolled'),
    (1, 2, 'Enrolled'),
    (2, 1, 'Enrolled');
END
GO
