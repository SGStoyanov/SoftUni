-- Problem 25.	Write a SQL query to display the average employee salary by department and job title.

SELECT
	d.Name,
	e.JobTitle,
	AVG(e.Salary) AS [Average Salary]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
GROUP BY	D.Name,
			e.JobTitle