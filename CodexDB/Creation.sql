
CREATE TABLE Instructors (
    InstructorID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    MonthlyEvaluation TEXT
);


CREATE TABLE Mentors (
    MentorID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    MonthlyEvaluation TEXT
);


CREATE TABLE Courses (
    CourseID INT NOT NULL,
    RoundNumber INT NOT NULL,
    Name VARCHAR(255) NOT NULL,
    Type VARCHAR(100),
    Category VARCHAR(100),
    MarketingCost DECIMAL(10, 2),
    SalesCost DECIMAL(10, 2),
    InstCost DECIMAL(10, 2),
    MentorCost DECIMAL(10, 2),
    WorkSpaceCost DECIMAL(10, 2),
    TotalCost AS (MarketingCost + SalesCost + InstCost + MentorCost + WorkSpaceCost),
    StartDate DATETIME NOT NULL,
    EndDate DATETIME,
    InstructorID INT NOT NULL,
    MentorID INT NOT NULL,
    PRIMARY KEY (CourseID, RoundNumber),
    FOREIGN KEY (InstructorID) REFERENCES Instructors(InstructorID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (MentorID) REFERENCES Mentors(MentorID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT CK_Courses_StartEndDate CHECK (StartDate < EndDate)
);



-- Create Students Table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE,
    Phone VARCHAR(50),
    PaymentType VARCHAR(50)
);

-- Update the Enrollments table to reference the new Courses table
CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    RoundNumber INT NOT NULL,
    GeneralGrade DECIMAL(5, 2),
    InstructorFeedback TEXT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (CourseID, RoundNumber) REFERENCES Courses(CourseID, RoundNumber) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT CK_Enrollments_Grade CHECK (GeneralGrade >= 0 AND GeneralGrade <= 100)
);

-- Update the Sessions table to reference the new Courses table
CREATE TABLE Sessions (
    SessionID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT NOT NULL,
    RoundNumber INT NOT NULL,
    MaterialLink TEXT,
    FOREIGN KEY (CourseID, RoundNumber) REFERENCES Courses(CourseID, RoundNumber) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Create Tasks Table
CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    EnrollmentID INT NOT NULL,
    Grade DECIMAL(5, 2),
    FOREIGN KEY (EnrollmentID) REFERENCES Enrollments(EnrollmentID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT CK_Tasks_Grade CHECK (Grade >= 0 AND Grade <= 100)
);

-- Create Projects Table
CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY IDENTITY(1,1),
    EnrollmentID INT NOT NULL,
    Grade DECIMAL(5, 2),
    FOREIGN KEY (EnrollmentID) REFERENCES Enrollments(EnrollmentID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT CK_Projects_Grade CHECK (Grade >= 0 AND Grade <= 100)
);

-- Create Quizzes Table
CREATE TABLE Quizzes (
    QuizID INT PRIMARY KEY IDENTITY(1,1),
    EnrollmentID INT NOT NULL,
    Grade DECIMAL(5, 2),
    FOREIGN KEY (EnrollmentID) REFERENCES Enrollments(EnrollmentID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT CK_Quizzes_Grade CHECK (Grade >= 0 AND Grade <= 100)
);

-- Create Attendance Table
CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY IDENTITY(1,1),
    SessionID INT NOT NULL,
    StudentID INT NOT NULL,
    IsAttended BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (SessionID) REFERENCES Sessions(SessionID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE ON UPDATE CASCADE
);
