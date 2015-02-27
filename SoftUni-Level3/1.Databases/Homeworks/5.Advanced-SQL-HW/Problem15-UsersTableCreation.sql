/* Problem 15.	Write a SQL statement to create a table Users.
Users should have username, password, full name and last login time. Choose appropriate data types for the table fields. 
Define a primary key column with a primary key constraint. Define the primary key column as identity to facilitate 
inserting records. Define unique constraint to avoid repeating usernames. Define a check constraint to ensure the 
password is at least 5 characters long. */

USE SoftUni;
GO

CREATE TABLE Users (
	Id int IDENTITY NOT NULL,
	Username nvarchar(50) NOT NULL UNIQUE,
	[PassWord]  nvarchar(100) NOT NULL,
	FullName nvarchar(100),
	LastLoginTime datetime,
	CONSTRAINT PK_Users PRIMARY KEY(Id),
	CONSTRAINT chk_Pass CHECK (LEN([PassWord]) >= 5)
);
GO

INSERT INTO Users (Username, [PassWord], FullName, LastLoginTime)
VALUES ('emz', 123456, 'Emz E. Emzov', '02.13.2015');
GO

INSERT INTO Users (Username, [PassWord], FullName, LastLoginTime)
VALUES ('gosho', 123456, 'Gosho Goshev', '02.14.2015');
GO

INSERT INTO Users (Username, [PassWord], FullName, LastLoginTime)
VALUES ('pesho', 123456, 'Pesho Peshev', '02.14.2015');
GO

INSERT INTO Users (Username, [PassWord], FullName, LastLoginTime)
VALUES ('moni', 1234567, 'Monika Petrova', '01.10.2015');
GO