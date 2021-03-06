-- Problem 18.	Write a SQL statement to add a column GroupID to the table Users.

ALTER TABLE [SoftUni].[dbo].[Users]
ADD GroupId INT;
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupId) REFERENCES Groups(Id)

INSERT INTO [SoftUni].[dbo].[Groups] (Name)
	VALUES ('Web Developers')
INSERT INTO [SoftUni].[dbo].[Groups] (Name)
	VALUES ('C#')
INSERT INTO [SoftUni].[dbo].[Groups] (Name)
	VALUES ('PHP')


UPDATE [SoftUni].[dbo].[Users]
SET GroupId = 1
WHERE Id = 1;
UPDATE [SoftUni].[dbo].[Users]
SET GroupId = 2
WHERE Id = 2;
UPDATE [SoftUni].[dbo].[Users]
SET GroupId = 3
WHERE Id = 3;