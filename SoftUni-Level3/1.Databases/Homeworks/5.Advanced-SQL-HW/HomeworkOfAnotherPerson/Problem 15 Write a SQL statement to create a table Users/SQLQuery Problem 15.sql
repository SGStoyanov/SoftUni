-- Problem 15.	Write a SQL statement to create a table Users

DROP TABLE [SoftUni].[dbo].[Users]
CREATE TABLE [SoftUni].[dbo].[Users] 
(
Id INT IDENTITY(1,1) NOT NULL,
Username NVARCHAR(50) NOT NULL,
[Password] NVARCHAR(50) NOT NULL,
FullName NVARCHAR(100) NOT NULL,
LastLoginTime DATETIME NOT NULL DEFAULT GETDATE(),
CONSTRAINT PK_Users PRIMARY KEY(Id),
CONSTRAINT UK_Users_Username UNIQUE (Username),
CONSTRAINT CHK_Users_Password_Length CHECK (LEN([Password]) >= 5)
)
GO