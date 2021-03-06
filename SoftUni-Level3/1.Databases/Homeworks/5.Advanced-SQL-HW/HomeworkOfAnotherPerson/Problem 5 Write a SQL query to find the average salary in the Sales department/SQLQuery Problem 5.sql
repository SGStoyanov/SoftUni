-- Problem 5.	Write a SQL query to find the average salary in the "Sales" department.

SELECT
	AVG(Salary) AS [Average Salary for Sales Department]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
