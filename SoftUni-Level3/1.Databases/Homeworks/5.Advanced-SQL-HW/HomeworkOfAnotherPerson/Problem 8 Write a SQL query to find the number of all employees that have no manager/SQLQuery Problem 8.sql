-- Problem 8.	Write a SQL query to find the number of all employees that have no manager.

SELECT
	COUNT(e.EmployeeID)
FROM [SoftUni].[dbo].[Employees] e
WHERE e.ManagerID IS NULL