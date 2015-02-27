/* Problem 22.	Write SQL statements to insert in the Users table the names of all employees from the Employees table.
Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). 
Use the same for the password, and NULL for last login time. */

USE SoftUni;
GO

INSERT INTO Users (Username, [PassWord], FullName)
SELECT DISTINCT SUBSTRING(e.FirstName, 1, 1) + '' + LOWER(e.LastName) AS Username, 
		SUBSTRING(e.FirstName, 1, 1) + '' + LOWER(e.LastName) + '---' AS [Password],
		e.FirstName + '' + e.LastName AS FullName
FROM Employees e
ORDER BY Username;
GO
