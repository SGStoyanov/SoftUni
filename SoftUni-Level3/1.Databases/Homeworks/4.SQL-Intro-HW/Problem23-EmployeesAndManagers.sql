-- Problem 23.	Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 

USE SoftUni;
GO

SELECT e.FirstName, e.LastName, e.JobTitle, m.ManagerId
FROM Employees e
LEFT OUTER JOIN Employees m ON e.EmployeeID = m.ManagerID;
GO

SELECT e.FirstName, e.LastName, e.JobTitle, m.ManagerId
FROM Employees e
RIGHT OUTER JOIN Employees m ON e.EmployeeID = m.ManagerID;
GO