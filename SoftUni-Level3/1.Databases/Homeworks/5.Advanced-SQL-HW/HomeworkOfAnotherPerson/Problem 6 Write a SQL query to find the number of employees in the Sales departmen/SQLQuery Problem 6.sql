-- Problem 6.	Write a SQL query to find the number of employees in the "Sales" department.

SELECT
	COUNT(e.EmployeeID)
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
