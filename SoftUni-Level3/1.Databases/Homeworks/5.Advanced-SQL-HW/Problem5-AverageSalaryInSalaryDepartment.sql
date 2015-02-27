-- Problem 5.	Write a SQL query to find the average salary in the "Sales" department.

USE SoftUni;
GO

SELECT ROUND(AVG(Salary), 2) AS [Average Salary]
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID
	  AND
	  d.Name = 'Sales'
GO