-- Problem 23.	Write a SQL statement that changes the password to NULL for all users that have not been in 
-- the system since 10.03.2010.

USE SoftUni;
GO

ALTER TABLE Users
ALTER COLUMN [PassWord] nvarchar(100) NULL;
GO

UPDATE Users
SET [PassWord] = NULL
WHERE LastLoginTime < '10.03.2010' OR LastLoginTime IS NULL;
GO