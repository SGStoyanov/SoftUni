-- Problem 20.	Write a SQL query to find all employees along with their manager.

USE SoftUni;
GO

SELECT e.FirstName, e.MiddleName, e.LastName, e.JobTitle, m.ManagerID
FROM Employees e
INNER JOIN Employees m
ON e.EmployeeID = m.ManagerID;
GO