/* Problem 32.	Start a database transaction, delete all employees from the 'Sales' department 
along with all dependent records from the pother tables. At the end rollback the transaction. */

BEGIN TRANSACTION

USE SoftUni;
DELETE Employees
	FROM Employees e
	JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name = 'Sales'

ROLLBACK TRANSACTION;
GO