-- Problem 23.	Write a SQL statement that changes the password to NULL for all users 
-- that have not been in the system since 10.03.2010.

ALTER TABLE [SoftUni].[dbo].[Users]
ALTER COLUMN Password NVARCHAR(50) NULL

UPDATE [SoftUni].[dbo].[Users]
SET PASSWORD = NULL
WHERE LastLoginTime <= DATEFROMPARTS(2010, 03, 10)