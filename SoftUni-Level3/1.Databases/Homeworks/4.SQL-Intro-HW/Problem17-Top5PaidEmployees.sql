-- Problem 17.	Write a SQL query to find the top 5 best paid employees.

USE SoftUni;
GO

SELECT TOP 5 FirstName, MiddleName, LastName, JobTitle, Salary
FROM Employees;
GO