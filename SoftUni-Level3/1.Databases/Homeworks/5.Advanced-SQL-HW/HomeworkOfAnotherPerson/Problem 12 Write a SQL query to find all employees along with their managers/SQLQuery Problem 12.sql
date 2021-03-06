-- Problem 12.	Write a SQL query to find all employees along with their managers.

SELECT
	e.FirstName + ' ' + e.LastName AS [Employeer Name],
	ISNULL(m.FirstName + ' ' + m.LastName, 'no manager') AS [Manager]
FROM [SoftUni].[dbo].[Employees] e
LEFT OUTER JOIN [SoftUni].[dbo].[Employees] m
	ON e.ManagerID = m.EmployeeID