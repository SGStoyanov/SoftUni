-- Problem 9.	Write a SQL query to find all departments and the average salary for each of them.

SELECT
	d.Name AS [Department],
	AVG(e.Salary) AS [Average Salary]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d
	ON d.DepartmentID = e.DepartmentID
GROUP BY	d.DepartmentID,
			d.Name