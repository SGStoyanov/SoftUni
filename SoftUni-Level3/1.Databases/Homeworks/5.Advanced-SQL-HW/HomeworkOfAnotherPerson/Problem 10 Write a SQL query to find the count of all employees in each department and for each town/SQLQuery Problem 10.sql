-- Problem 10.	Write a SQL query to find the count of all employees in each department and for each town.

SELECT
	d.Name AS [Department],
	t.Name AS [Town],
	COUNT(e.EmployeeID) AS [Employess Count]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d
	ON d.DepartmentID = e.DepartmentID
JOIN [SoftUni].[dbo].[Addresses] a
	ON a.AddressID = e.AddressID
JOIN [SoftUni].[dbo].[Towns] t
	ON t.TownID = a.TownID
GROUP BY	d.Name,
			t.Name