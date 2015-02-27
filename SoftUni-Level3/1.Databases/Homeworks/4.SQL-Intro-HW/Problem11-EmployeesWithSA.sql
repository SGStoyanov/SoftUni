-- Problem 11.	Write a SQL query to find the names of all employees whose first name starts with "SA".

USE SoftUni;
GO

SELECT FirstName, MiddleName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%';
GO