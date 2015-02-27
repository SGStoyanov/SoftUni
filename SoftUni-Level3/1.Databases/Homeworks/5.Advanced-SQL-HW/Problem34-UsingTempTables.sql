/* Problem 34.	Find how to use temporary tables in SQL Server.
Using temporary tables backup all records from EmployeesProjects and restore them back after 
dropping and re-creating the table. */

USE SoftUni;
GO

SELECT * INTO #TempEmployeesProjects
FROM EmployeesProjects;
GO

DROP TABLE EmployeesProjects;
GO

SELECT * INTO EmployeesProjects
FROM #TempEmployeesProjects;
GO