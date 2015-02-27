-- Problem 4.	Write a SQL query to find the average salary in the department #1.

USE SoftUni;
GO

SELECT ROUND(AVG(e.Salary), 2) AS [Average Salary]
FROM Employees e, Departments d
WHERE e.DepartmentID = 1
GO