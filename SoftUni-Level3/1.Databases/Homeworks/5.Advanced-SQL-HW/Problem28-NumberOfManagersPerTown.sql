-- Problem 28.	Write a SQL query to display the number of managers from each town.

USE SoftUni;
GO

SELECT t.name AS [Town], COUNT(DISTINCT e.ManagerID) AS [Number of Managers]
FROM Employees e
	JOIN Employees m ON m.EmployeeID = e.ManagerID
	JOIN Addresses a ON a.AddressID = m.AddressID
	JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name;
GO