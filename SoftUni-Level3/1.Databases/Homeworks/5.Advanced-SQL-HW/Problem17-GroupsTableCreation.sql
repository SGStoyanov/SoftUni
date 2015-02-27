/* Problem 17.	Write a SQL statement to create a table Groups. 
Groups should have unique name (use unique constraint). Define primary key and identity column. */

USE SoftUni;
GO

CREATE TABLE Groups (
	Id int IDENTITY NOT NULL,
	Name nvarchar(50) UNIQUE NOT NULL,
	CONSTRAINT PK_Groups PRIMARY KEY(Id)
);
GO