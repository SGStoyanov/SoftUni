--Problem 31.	
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--For each change keep the old record data, the new record data and 
--the command (insert / update / delete).

CREATE TABLE WorkHoursLogs
(
    WHLogId INT IDENTITY(1, 1) NOT NULL,
    Command varchar(10) NOT NULL,

	WorkHoursId_Old int NULL,
    EmployeeId_Old INT  NULL,
	WorkDate_Old DATETIME NULL,
	Task_Old NVARCHAR(500)  NULL,
	WorkHours_Old DECIMAL(5,2) NULL, 
	Comments_Old NVARCHAR(MAX) NULL,

	WorkHoursId_New int NULL,
    EmployeeId_New INT NULL,
	WorkDate_New DATETIME NULL,
	Task_New NVARCHAR(500) NULL,
	WorkHours_New DECIMAL(5,2) NULL, 
	Comments_New NVARCHAR(MAX) NULL,

	CONSTRAINT PK_WorkHoursLogs PRIMARY KEY (WHLogId)
)
GO

DROP TRIGGER TR_BeforeInsert_WorkHours
GO
CREATE TRIGGER TR_BeforeInsert_WorkHours
    ON WorkHours
    FOR INSERT
    AS
    BEGIN
SET NOCOUNT ON
INSERT INTO dbo.WorkHoursLogs (Command,
WorkHoursId_New, EmployeeId_New, WorkDate_New, Task_New, WorkHours_New, Comments_New)
	SELECT
		'INSERT',
		i.WorkHoursId,
		i.EmployeeId,
		i.WorkDate,
		i.Task,
		i.WorkHours,
		i.Comments
	FROM INSERTED i
END
GO

DROP TRIGGER TR_BeforeDelete_WorkHours
GO
CREATE TRIGGER TR_BeforeDelete_WorkHours
 ON WorkHours
    FOR DELETE
    AS
    BEGIN
SET NOCOUNT ON
INSERT INTO WorkHoursLogs (Command,
WorkHoursId_Old, EmployeeId_Old, WorkDate_Old, Task_Old, WorkHours_Old, Comments_Old)
	SELECT
		'DELETE',
		d.WorkHoursId,
		d.EmployeeId,
		d.WorkDate,
		d.Task,
		d.WorkHours,
		d.Comments
	FROM DELETED d
END
GO

DROP TRIGGER TR_BeforeUpdate_WorkHours
GO
CREATE TRIGGER TR_BeforeUpdate_WorkHours
 ON WorkHours
    FOR UPDATE
    AS
    BEGIN
SET NOCOUNT ON
INSERT INTO WorkHoursLogs (Command,
WorkHoursId_Old, EmployeeId_Old, WorkDate_Old, Task_Old, WorkHours_Old, Comments_Old,
WorkHoursId_New, EmployeeId_New, WorkDate_New, Task_New, WorkHours_New, Comments_New)
	SELECT
		'UPDATE',
		d.WorkHoursId,
		d.EmployeeId,
		d.WorkDate,
		d.Task,
		d.WorkHours,
		d.Comments,

		i.WorkHoursId,
		i.EmployeeId,
		i.WorkDate,
		i.Task,
		i.WorkHours,
		i.Comments
	FROM	DELETED d,
			INSERTED i
END
GO