-- Problem 11.	Write a SQL query to find all managers that have exactly 5 employees.
SELECT
	e.FirstName,
	e.LastName,
	5 AS [Employees count]
FROM [SoftUni].[dbo].[Employees] e
WHERE 5 IN (SELECT
	COUNT(*) AS empCount
FROM [SoftUni].[dbo].[Employees] m
WHERE e.EmployeeID = m.ManagerID)