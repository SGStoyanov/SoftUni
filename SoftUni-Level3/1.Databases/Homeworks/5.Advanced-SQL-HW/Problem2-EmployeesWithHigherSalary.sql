-- Problem 2.	Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher 
-- than the minimal salary for the company.

USE SoftUni;
GO

SELECT FirstName, LastName, Salary 
FROM Employees e
WHERE Salary BETWEEN (SELECT MIN(Salary) FROM Employees) AND (SELECT MIN(Salary) * 1.10 FROM Employees)
ORDER BY Salary;
GO