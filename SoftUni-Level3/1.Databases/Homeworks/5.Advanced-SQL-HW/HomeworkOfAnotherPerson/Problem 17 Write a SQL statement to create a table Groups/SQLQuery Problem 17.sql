-- Problem 17.	Write a SQL statement to create a table Groups. 

DROP TABLE [SoftUni].[dbo].[Groups]
CREATE TABLE [SoftUni].[dbo].[Groups] 
(
Id INT IDENTITY (1,1) NOT NULL,
Name NVARCHAR(50) NOT NULL,
CONSTRAINT PK_Groups PRIMARY KEY(Id),
CONSTRAINT UK_Groups_Name UNIQUE (Name)
)