--Problem 34.	
--Find how to use temporary tables in SQL Server.
--Using temporary tables backup all records from EmployeesProjects and 
--restore them back after dropping and re-creating the table.

CREATE TABLE #EmployeesProjectSummary(
EmployeeID int,
ProjectID int
)
GO

INSERT INTO #EmployeesProjectSummary
	SELECT
		EmployeeID,
		ProjectID
	FROM employeesprojects
GO

DROP TABLE employeesprojects
GO

CREATE TABLE EmployeesProjects(
EmployeeID int ,
ProjectID int,
CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
CONSTRAINT FK_Employees_EmployeesProjects FOREIGN KEY (EmployeeID) REFERENCES employees(EmployeeID)
);

INSERT INTO EmployeesProjects
	SELECT
		*
	FROM #EmployeesProjectSummary
GO

DROP TABLE #EmployeesProjectSummary
GO