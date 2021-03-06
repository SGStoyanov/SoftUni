-- Problem 26.	Write a SQL query to display the minimal employee salary 
-- by department and job title along with the name of some of the employees that take it.

SELECT
	d.Name AS [Department],
	e.JobTitle,
	(SELECT
		MAX(minSalary.FirstName)
	FROM [SoftUni].[dbo].[Employees] AS minSalary
	WHERE d.DepartmentID = minSalary.DepartmentID
	AND MIN(e.Salary) = minSalary.Salary
	AND e.JobTitle = minSalary.JobTitle)
	AS [FirstName],
	MIN(e.Salary) AS [Min Salary]
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
GROUP BY	d.Name,
			d.DepartmentID,
			e.DepartmentID,
			e.JobTitle