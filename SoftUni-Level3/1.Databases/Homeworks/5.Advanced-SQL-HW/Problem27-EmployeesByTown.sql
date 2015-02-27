-- Problem 27.	Write a SQL query to display the town where maximal number of employees work.

USE SoftUni;
GO

SELECT TOP 1(t.Name) AS [Town], COUNT(*) AS [Number of Employees]
FROM Towns t
JOIN Addresses a ON a.TownID = t.TownID
JOIN Employees e ON e.AddressID = a.AddressID 
GROUP BY t.Name
ORDER BY COUNT(*) DESC; 
GO

SELECT * FROM Employees;