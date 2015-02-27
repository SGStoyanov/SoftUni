/* Problem 2.	Create a stored procedure
Your task is to create a stored procedure that accepts a number as a parameter and returns all persons 
who have more money in their accounts than the supplied number. */

USE BankDatabase;
GO

/* SELECT * FROM Accounts;
SELECT * FROM Persons;
GO */

CREATE PROCEDURE uspMoneyReport
	@number INT
AS
	SELECT p.[First Name] + ' ' + p.[Last Name] AS [Full Name], a.[Money]
	FROM Persons p
	JOIN Accounts a ON a.Person_Id = p.P_Id
	GROUP BY a.[Money], p.[First Name], p.[Last Name]
	HAVING a.[Money] > @number;
GO

EXEC uspMoneyReport @number = 600;
GO