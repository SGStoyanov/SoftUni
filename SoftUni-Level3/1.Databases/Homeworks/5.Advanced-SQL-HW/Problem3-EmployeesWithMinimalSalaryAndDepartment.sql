/* Problem 3.	Write a SQL query to find the full name, salary and department of the employees that take the minimal 
salary in their department. */

USE SoftUni;
GO

SELECT e.FirstName + ' ' + e.MiddleName + ' ' + e.LastName AS [Full Name], e.Salary, d.Name AS [Department Name]
FROM Employees e, Departments d
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees
	 WHERE e.DepartmentID = d.DepartmentID)
ORDER BY e.FirstName;
GO