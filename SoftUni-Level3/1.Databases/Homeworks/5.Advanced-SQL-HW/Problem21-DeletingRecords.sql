/* Problem 21.	Write SQL statements to delete some of the records from the Users and Groups tables. */

USE SoftUni;
GO

DELETE FROM Users
WHERE FullName = 'User Userov 3' OR Username = 'User1'; -- Deleting two users at the same time
GO

DELETE FROM Groups
WHERE Name = 'WeakGroup';
GO