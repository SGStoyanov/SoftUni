-- Problem 24.	Write a SQL statement that deletes all users without passwords (NULL password).

DELETE FROM [SoftUni].[dbo].[Users]
WHERE Password IS NULL