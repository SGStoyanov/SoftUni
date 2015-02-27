-- Problem 22.	Write a SQL query to find all departments and all town names as a single list.

USE SoftUni;
GO

SELECT d.Name as [Departments and Towns]
FROM Departments d
UNION ALL
SELECT t.Name
FROM Towns t;
GO