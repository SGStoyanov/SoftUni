-- Problem 3.	Write a SQL query to find the full name, salary and 
-- department of the employees that take the minimal salary in their department.

SELECT
	FirstName + ' ' + LastName AS [Employee Name],
	Salary,
	d.Name
FROM [SoftUni].[dbo].[Employees] e
JOIN [SoftUni].[dbo].[Departments] d
	ON d.DepartmentID = e.DepartmentID
WHERE e.Salary = (SELECT
	MIN(Salary)
FROM [SoftUni].[dbo].[Employees] emp
WHERE emp.DepartmentID = e.DepartmentID)