/* Problem 12.	Write a SQL query to find all employees along with their managers.
For employees that do not have manager display the value "(no manager)". */


USE SoftUni;
GO

SELECT e.FirstName + ' ' + ISNULL(e.MiddleName + ' ', '') + e.LastName AS [Employee FULL Name],  
	   ISNULL(m.FirstName + ' ' + ISNULL(m.MiddleName + ' ', '') + m.LastName, 'No manager') AS [Manager FULL Name]
FROM Employees e
	LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID;
GO