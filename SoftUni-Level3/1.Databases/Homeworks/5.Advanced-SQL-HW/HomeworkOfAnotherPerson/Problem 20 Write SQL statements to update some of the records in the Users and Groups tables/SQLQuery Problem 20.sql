-- Problem 20.	Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE [SoftUni].[dbo].[Groups]
SET Name = 'JavaScript'
WHERE Name = 'PHP'

UPDATE [SoftUni].[dbo].[Groups]
SET Name = 'OOP C#'
WHERE Name = 'C#'

UPDATE [SoftUni].[dbo].[Users]
SET Username = 'valkata'
WHERE Username = 'valka'