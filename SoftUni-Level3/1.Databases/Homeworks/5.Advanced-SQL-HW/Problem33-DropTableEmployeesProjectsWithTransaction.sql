/* Problem 33.	Start a database transaction and drop the table EmployeesProjects.
Then how you could restore back the lost table data? */

BEGIN TRAN

USE SoftUni;

DROP TABLE EmployeesProjects;

ROLLBACK TRAN;
GO