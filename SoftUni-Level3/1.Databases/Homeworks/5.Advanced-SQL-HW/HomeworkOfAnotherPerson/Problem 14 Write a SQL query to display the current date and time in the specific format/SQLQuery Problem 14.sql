-- Problem 14.	Write a SQL query to display the current date and time in the following format "day.month.year 

SELECT
	CONVERT(NVARCHAR, GETDATE(), 102) + ' ' + CONVERT(NVARCHAR, GETDATE(), 114) AS [Currnet Date]