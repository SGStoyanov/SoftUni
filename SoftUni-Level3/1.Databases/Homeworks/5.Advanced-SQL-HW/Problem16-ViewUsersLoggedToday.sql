/* Problem 16.	Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
Test if the view works correctly. */

USE SoftUni;
GO

DECLARE @d DATETIME = GETDATE();
SELECT FORMAT (@d, 'dd.MM.yyyy');
GO

CREATE VIEW V_UsersLoggedToday
AS SELECT Username, FullName, LastLoginTime
FROM Users
WHERE DAY(LastLoginTime) = DAY(GETDATE());
GO