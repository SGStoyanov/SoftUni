-- Problem 6.	Write a SQL query to find the number of employees in the "Sales" department.

USE SoftUni;
GO

SELECT COUNT(*) AS [Sales Employees Count]
FROM Employees
WHERE DepartmentID = 
	(SELECT DepartmentID FROM Departments
	 WHERE Name = 'Sales');
GO