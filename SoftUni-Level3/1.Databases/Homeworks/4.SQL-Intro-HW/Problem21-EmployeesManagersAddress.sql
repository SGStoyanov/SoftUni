-- Problem 21.	Write a SQL query to find all employees, along with their manager and their address.

USE SoftUni;
GO

SELECT e.FirstName, e.LastName, e.JobTitle, m.ManagerId, a.AddressText
FROM Employees e 
INNER JOIN Employees m ON e.EmployeeID = m.ManagerID
INNER JOIN Addresses a ON e.EmployeeID = a.AddressID;
GO