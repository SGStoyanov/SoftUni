-- Problem 16.	Write a SQL statement to create a view that displays 
-- the users from the Users table that have been in the system today.

IF OBJECT_ID('dbo.Users_View','V') IS NOT NULL
DROP VIEW dbo.Users_View;
GO
USE SoftUni;
GO
CREATE VIEW dbo.Users_View AS
SELECT
	*
FROM [SoftUni].[dbo].[Users]
WHERE LastLoginTime > DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), -1)