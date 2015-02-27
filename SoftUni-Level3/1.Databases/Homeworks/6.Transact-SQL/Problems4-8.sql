/* Problem 4.	Create a stored procedure that uses the function from the previous example.
Your task is to create a stored procedure that uses the function from the previous example 
to give an interest to a person's account for one month. It should take the AccountId and the interest rate as parameters. */

USE BankDatabase;
GO

CREATE PROCEDURE usp_CalculateInterestForOneMonth (@accountId int, @interestRate money)
AS 
	DECLARE @oldSum money;
	SELECT @oldSum = a.[Money]
	FROM Accounts a
	WHERE a.A_Id = @accountId;

	DECLARE @newSum money;
	SET @newSum = dbo.uspProfitCalculator(@oldSum, @interestRate, 1);

	UPDATE Accounts 
	SET [Money] = @newSum
	WHERE A_Id = @accountId;
GO

EXEC usp_CalculateInterestForOneMonth 1, 10;
GO

SELECT * FROM Accounts;
GO

/* Problem 5. Add two more stored procedures WithdrawMoney and DepositMoney.
Add two more stored procedures WithdrawMoney (AccountId, money) and DepositMoney (AccountId, money) 
that operate in transactions. */

USE BankDatabase;
GO

CREATE PROCEDURE usp_DepositMoney (@AccountId int, @Money money)
AS
	BEGIN TRANSACTION
		DECLARE @oldSum money;
		SELECT @oldSum = a.[Money]
		FROM Accounts a
		WHERE a.A_Id = @AccountId;

		DECLARE @newSum money;
		SET @newSum = @oldSum + @Money;

		UPDATE Accounts
		SET [Money] = @newSum
		WHERE A_Id = @AccountId;

		IF @@ERROR <> 0
			BEGIN
				ROLLBACK
				RAISERROR('Error while adding finds to ', 16, 1)
				RETURN
			END
	COMMIT;
GO

-- Testing
EXEC usp_DepositMoney 2, 500;
GO

CREATE PROCEDURE usp_WithdrawMoney (@AccountId int, @Money money)
AS
	BEGIN TRANSACTION
		DECLARE @oldSum money;
		SELECT @oldSum = a.[Money]
		FROM Accounts a
		WHERE a.A_Id = @AccountId;

		DECLARE @newSum money;
		SET @newSum = @oldSum - @Money;

		UPDATE Accounts
		SET [Money] = @newSum
		WHERE A_Id = @AccountId;

		IF @@ERROR <> 0
			BEGIN
				ROLLBACK
				RAISERROR('Error while adding finds', 16, 1)
				RETURN
			END

		-- Some checks for illegal operations
		IF @oldSum <= 0 OR @Money > @oldSum
			BEGIN
				ROLLBACK
				RAISERROR('Not enough money in the bank account!', 16, 1)
				RETURN
			END
	COMMIT;
GO

-- Testing
SELECT * FROM Accounts;
GO

EXEC usp_WithdrawMoney 2, 1000; -- if the withdrawing money are more than the available there will be an error
GO

-- End of Problem 5

/* Problem 6.	Create table Logs.
Create another table – Logs (LogID, AccountID, OldSum, NewSum). 
Add a trigger to the Accounts table that enters a new entry into the Logs table every 
time the sum on an account changes. */

USE BankDatabase;
GO

CREATE TABLE Logs (
	LogId int IDENTITY PRIMARY KEY NOT NULL,
	AccountId int NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL
);
GO

CREATE TRIGGER tr_AccountsModification ON Accounts FOR UPDATE
AS
	BEGIN  
		SET NOCOUNT ON;
		INSERT INTO Logs (AccountId, OldSum, NewSum)
			SELECT  i.A_Id,
					d.[Money],
					i.[Money]
			FROM INSERTED i, DELETED d
	END;
GO

CREATE TRIGGER tr_AccountsDeletion ON Accounts FOR DELETE
AS
	BEGIN  
		INSERT INTO Logs (AccountId, OldSum, NewSum)
		SELECT d.A_Id, d.[Money], 0 FROM DELETED d
	END;
GO

CREATE TRIGGER tr_AccountsInsertion ON Accounts FOR INSERT
AS
	BEGIN
		INSERT INTO Logs (AccountId, OldSum, NewSum)
		SELECT i.A_Id, 0, i.[Money] FROM INSERTED i
	END;
GO

-- Testing
SELECT * FROM Logs;
GO

SELECT * FROM Accounts;
GO

UPDATE Accounts
SET [Money] = 9999
WHERE A_Id = 9;
GO

INSERT INTO Accounts (Person_Id, [Money])
VALUES (4, 1234);
GO

DELETE FROM Accounts
WHERE A_Id = 6;
GO

-- End of Problem 6

/* Problem 8.	Using database cursor write a T-SQL
Using database cursor write a T-SQL script that scans all employees and their addresses and prints all 
pairs of employees that live in the same town.
Example:
Wood: John Wood Redmond John
Hill: John Wood Redmond Annette
Feng: John Wood Redmond Hanying
Sousa: John Wood Redmond Anibal
Glimp: John Wood Redmond Diane
Pournasseh: John Wood Redmond Houman
Kane: John Wood Redmond Lori
… */

USE SoftUni;
GO

DECLARE empCursor CURSOR  FOR 
	SELECT e.FirstName + ' ' + e.LastName, t.Name
	FROM Employees e
	INNER JOIN Addresses a ON a.AddressID = e.AddressID
	INNER JOIN Towns t ON t.TownID = a.TownID
	ORDER BY t.Name

OPEN empCursor
DECLARE @town nvarchar(100), @fullName nvarchar(100), 
		@currentTown nvarchar(100), @currentFullName nvarchar(100)

FETCH NEXT FROM empCursor INTO @fullName, @town
WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @currentTown = @town;
		SET @currentFullName = @fullName
		FETCH NEXT FROM empCursor INTO @fullName, @town

		IF(@currentTown = @town)
			PRINT @town + ': ' + @fullName + ', ' + @currentFullName;
	END;
CLOSE empCursor;
DEALLOCATE empCursor;

--- End of Problem 8