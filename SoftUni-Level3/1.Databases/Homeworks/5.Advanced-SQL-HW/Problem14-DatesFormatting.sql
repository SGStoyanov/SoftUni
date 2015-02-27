/* Problem 14.	Write a SQL query to display the current date and time in the following format 
"day.month.year hour:minutes:seconds:milliseconds". Search in Google to find how to format dates in SQL Server. */
-- 11.02.2015 18:50:02:960

USE SoftUni;
GO

DECLARE @d DATETIME = GETDATE();
SELECT FORMAT (@d, 'dd.MM.yyyy hh:mm:ss:ms')
GO