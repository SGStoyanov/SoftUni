-- Problem 21.	Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE FROM [SoftUni].[dbo].[Users]
WHERE Username = 'valkata'


DELETE FROM [SoftUni].[dbo].[Groups]
WHERE Name = 'OOP C#'
