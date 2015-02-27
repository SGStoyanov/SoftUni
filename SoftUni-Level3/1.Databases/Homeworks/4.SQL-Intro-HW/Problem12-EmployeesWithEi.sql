-- Problem 12.	Write a SQL query to find the names of all employees whose last name contains "ei".

USE SoftUni;
GO

SELECT FirstName, MiddleName, LastName
FROM Employees
WHERE LastName LIKE '%ei%';
GO