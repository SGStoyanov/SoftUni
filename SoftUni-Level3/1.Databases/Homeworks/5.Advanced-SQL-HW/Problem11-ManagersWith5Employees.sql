-- Problem 11.	Write a SQL query to find all managers that have exactly 5 employees.

USE SoftUni;
GO

SELECT m.FirstName, m.LastName, COUNT(*) AS Employees
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.EmployeeID) = 5;
GO