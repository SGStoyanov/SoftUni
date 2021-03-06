-- Problem 28.	Write a SQL query to display the number of managers from each town
SELECT
	Managers.TownName AS Town,
	COUNT(Managers.managerId) AS [Number of managers]
FROM (SELECT DISTINCT
	e.EmployeeID AS managerId,
	t.Name AS TownName
FROM Employees e
JOIN Employees m
	ON e.EmployeeID = m.ManagerID
JOIN Addresses a
	ON a.AddressID = e.AddressID
JOIN Towns t
	ON t.TownID = a.TownID) AS Managers
GROUP BY Managers.TownName