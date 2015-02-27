-- Problem 1.	Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.

USE SoftUni;
GO

SELECT FirstName, LastName, JobTitle, Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees);
GO