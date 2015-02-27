/* Problem 26.	Write a SQL query to display the minimal employee salary by department and job title along 
with the name of some of the employees that take it. */

USE SoftUni;
GO

SELECT * FROM Employees;

SELECT d.Name AS Department, e.JobTitle AS [Job Title], e.FirstName AS [First Name], MIN(e.Salary) AS [Min Salary]
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName
ORDER BY d.Name;
GO