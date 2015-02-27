-- Problem 24.	Write a SQL statement that deletes all users without passwords (NULL password).

USE SoftUni;
GO

DELETE Users
WHERE [PassWord] IS NULL;
GO

-- SELECT * FROM Users;