/* Problem 31.	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
For each change keep the old record data, the new record data and the command (insert / update / delete). */

USE SoftUni;
GO

SELECT * FROM WorkHours;
GO

CREATE TABLE WorkHoursLogs (
	WorkHoursLogID INT IDENTITY,
	LogCommand NVARCHAR(6) NOT NULL,
	OldHours INT NULL,
	OldDate DATE NULL,
	OldEmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID) NULL,
	OldTask NVARCHAR(200) NULL,
	OldWorkHours FLOAT NULL,
	OldComment NVARCHAR(200) NULL,
	NewWorkHoursID INT NULL,
	NewDate DATE NULL,
	NewEmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID) NULL,
	NewTask NVARCHAR(200) NULL,
	NewHours FLOAT NULL,
	NewComment NVARCHAR(200) NULL,
	CONSTRAINT PK_WorkHoursLogs PRIMARY KEY(WorkHoursLogID)
);
GO
 
CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
BEGIN  
    SET NOCOUNT ON;
    INSERT INTO WorkHoursLogs
    SELECT 'UPDATE',
            d.WorkHoursID,
            d.[Date],
            d.EmployeeID,
            d.Task,
            d.[Hours],
            d.Comment,
            i.WorkHoursID,
            i.[Date],
            i.EmployeeID,
            i.Task,
            i.[Hours],
            i.Comment
        FROM INSERTED i, DELETED d
END;
GO
 
CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
BEGIN  
    INSERT INTO WorkHoursLogs
    SELECT 'INSERT', NULL, NULL, NULL, NULL, NULL, NULL, *
        FROM INSERTED
END;
GO

CREATE TRIGGER tr_WorkHoursDelete ON WorkHours FOR DELETE
AS
BEGIN  
    INSERT INTO WorkHoursLogs
    SELECT 'DELETE', * , NULL, NULL, NULL, NULL, NULL, NULL
        FROM DELETED
END;
GO