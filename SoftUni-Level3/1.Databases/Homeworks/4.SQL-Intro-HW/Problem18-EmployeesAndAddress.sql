-- Problem 18.	Write a SQL query to find all employees along with their address.

USE SoftUni;
GO

SELECT e.FirstName, e.LastName, a.AddressText 
FROM Employees e
INNER JOIN Addresses a
ON e.EmployeeID = a.AddressID;
GO