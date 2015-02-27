-- Problem 8.	Write a SQL query to find the number of all employees that have no manager.

USE SoftUni;
GO

SELECT COUNT(*) AS [Employees with Manager]
FROM Employees
WHERE ManagerID IS NULL;
GO