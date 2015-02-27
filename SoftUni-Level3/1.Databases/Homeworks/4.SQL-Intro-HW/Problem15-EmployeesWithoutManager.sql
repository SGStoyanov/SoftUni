-- Problem 15.	Write a SQL query to find all employees that do not have manager.

USE SoftUni;
GO

SELECT FirstName, MiddleName, LastName, JobTitle, Salary, ManagerID
FROM Employees
WHERE ManagerID IS NULL
ORDER BY Salary ASC;
GO