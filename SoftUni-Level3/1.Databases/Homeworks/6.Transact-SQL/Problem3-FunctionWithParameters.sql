/* Problem 3.	Create a function with parameters
Your task is to create a function that accepts as parameters – sum, yearly interest rate and number of months. 
It should calculate and return the new sum. Write a SELECT to test whether the function works as expected. */

CREATE FUNCTION dbo.uspProfitCalculator (
	@sum money,
	@yearlyInterestRate money,
	@numberOfMonths int)
	RETURNS money
AS
	BEGIN
		DECLARE @monthlyInterestRate money
		SET @monthlyInterestRate = @yearlyInterestRate / 12;
		RETURN @sum * (1 + @numberOfMonths * @monthlyInterestRate / 100)
	END;
GO

USE BankDatabase;
GO

SELECT p.[First Name] + ' ' + p.[Last Name] AS [Customer Full Name], 
	   dbo.uspProfitCalculator(a.[Money], 5.2, 12) AS [Sum After Interest]
FROM Persons p
JOIN Accounts a ON a.Person_Id = p.P_Id
ORDER BY [Sum After Interest] DESC;
GO