-- Problem 25.	Write a SQL query to display the average employee salary by department and job title.
-- Department, Job Title, Average Salary

USE SoftUni;
GO

SELECT * FROM Employees;

SELECT d.Name AS Department, e.JobTitle AS [Job Title], e.Salary
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.Salary
ORDER BY e.Salary;
GO