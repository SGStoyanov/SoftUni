-- Problem 7.	Write a SQL query to find the number of all employees that have manager.

USE SoftUni;
GO

SELECT COUNT(*) AS [Employees with Manager]
FROM Employees
WHERE ManagerID IS NOT NULL;
GO