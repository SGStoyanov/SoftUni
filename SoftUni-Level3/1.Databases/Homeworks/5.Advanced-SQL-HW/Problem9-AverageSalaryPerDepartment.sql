-- Problem 9.	Write a SQL query to find all departments and the average salary for each of them.

USE SoftUni;
GO

SELECT ROUND(AVG(Salary), 2) AS AverageSalary, d.Name AS DepartmentName
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY AverageSalary
GO