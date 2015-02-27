-- Problem 14.	Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

USE SoftUni;
GO

SELECT FirstName, MiddleName, LastName, Salary
FROM Employees
WHERE Salary = 25000
OR Salary = 14000
OR Salary = 12500
OR Salary = 23600
ORDER BY Salary ASC;
GO