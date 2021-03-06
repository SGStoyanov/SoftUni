-- Problem 27.	Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 t.Name, COUNT(e.EmployeeID) AS [Number of Employees]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Addresses] a
ON e.AddressID = a.AddressID
JOIN [SoftUni].[dbo].[Towns] t
ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(e.EmployeeID) DESC