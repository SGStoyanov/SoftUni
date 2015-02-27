/* Problem 13.	Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
Use the built-in LEN(str) function. */

USE SoftUni;
GO

SELECT FirstName, MiddleName, LastName, LEN(LastName) AS [LastName Length]
FROM Employees
WHERE LEN(LastName) = 5;
GO