-- Problem 10.	Write a SQL query to find the count of all employees in each department and for each town.

USE SoftUni;
GO

SELECT t.Name AS Town, d.Name AS Department, COUNT(*) AS EmployeesCount
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID
JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY t.Name, d.Name
GO