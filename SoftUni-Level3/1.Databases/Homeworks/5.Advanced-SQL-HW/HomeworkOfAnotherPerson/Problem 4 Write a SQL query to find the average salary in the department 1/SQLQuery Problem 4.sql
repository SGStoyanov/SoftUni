-- Problem 4.	Write a SQL query to find the average salary in the department #1.

SELECT
	AVG(Salary) AS [Average Salary]
FROM [SoftUni].[dbo].[Employees] e
WHERE e.DepartmentID = 1