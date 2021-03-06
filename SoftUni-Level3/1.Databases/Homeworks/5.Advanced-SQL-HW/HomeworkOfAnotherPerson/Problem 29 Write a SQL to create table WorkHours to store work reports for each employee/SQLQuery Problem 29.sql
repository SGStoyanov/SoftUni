-- Problem 29.	Write a SQL to create table WorkHours to store work reports for each employee
CREATE TABLE dbo.WorkHours
(
    WorkHoursId int IDENTITY(1,1) NOT NULL,
    EmployeeId INT NOT NULL,
	WorkDate DATETIME NULL,
	Task NVARCHAR(500) NOT NULL,
	WorkHours DECIMAL(5,2) NOT NULL, 
	Comments NVARCHAR(MAX) NULL,
	CONSTRAINT PK_WorkHours PRIMARY KEY (WorkHoursId),
	CONSTRAINT FK_WorkHours_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeID)
)
GO