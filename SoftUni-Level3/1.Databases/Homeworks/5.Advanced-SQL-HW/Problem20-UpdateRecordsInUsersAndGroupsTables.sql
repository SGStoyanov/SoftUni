-- Problem 20.	Write SQL statements to update some of the records in the Users and Groups tables.

USE SoftUni;
GO

UPDATE Users
SET GroupID = 1;
GO

UPDATE Users
SET GroupID = 3
WHERE Username = 'User1' OR Username = 'User2' OR Username = 'User3' OR Username = 'User4' OR Username = 'User5';
GO

UPDATE Users
SET GroupID = 2, [PassWord] = 'TheBiggestSecret'
WHERE Username = 'Admin';
GO

UPDATE Groups
SET Name = 'ThirdGroup'
WHERE Name = 'Third';
GO

-- SELECT * FROM Users;
-- SELECT * FROM Groups;