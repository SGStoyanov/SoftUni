/* Persons (id (PK), first name, last name, SSN) and Accounts (id (PK), person id (FK), balance). 
Insert few records for testing. 
Write a stored procedure that selects the full names of all persons. */

USE BankDatabase;
GO

CREATE TABLE Persons (
	P_Id INT IDENTITY NOT NULL,
	[First Name] NVARCHAR(50) NOT NULL,
	[Last Name] NVARCHAR(50) NOT NULL,
	SSN NVARCHAR(50),
	PRIMARY KEY (P_Id)
);
GO

CREATE TABLE Accounts (
	A_Id INT IDENTITY NOT NULL UNIQUE,
	Person_Id INT NOT NULL,
	[Money] money,
	PRIMARY KEY (A_ID),
	FOREIGN KEY (Person_Id) REFERENCES Persons(P_Id)
);
GO

DROP TABLE Accounts

INSERT INTO Persons([First Name], [Last Name], SSN)
VALUES 
	('Stoyan', 'Stoyanov', 'A919201'),
	('Petar', 'Petrov', 'A929302'),
	('George', 'Georgiev', 'C12912'),
	('Radoslav', 'Radev', 'D032192')
;
GO

-- SELECT * FROM Persons;
-- GO

INSERT INTO Accounts (Person_Id, [Money])
VALUES
	(1, 1000),
	(2, 520),
	(3, 5620.50),
	(4, 120);
GO

-- SELECT * FROM Accounts;
-- GO

CREATE PROCEDURE 
	uspGetPersonsFullName
AS
	SELECT [First Name] + ' ' + [Last Name] AS [Full Name]
	FROM Persons;
GO

DROP PROCEDURE uspGetPersonsFullName;
GO

EXEC uspGetPersonsFullName;
GO