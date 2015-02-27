/* Problem 1.	Create a table in SQL Server
Your task is to create a table in SQL Server with 10 000 000 entries (date + text). Search in the table by date range. 
Check the speed (without caching).
You should submit a SQL file with queries and screenshot of speed comparison as a part of your homework. */

USE master;
GO

CREATE DATABASE JustATestDatabase;
GO

USE JustATestDatabase;
GO

IF NOT EXISTS (SELECT * FROM SYSOBJECTS WHERE name='EntriesTable' and xtype='U')
	CREATE TABLE EntriesTable (
		EntriesId INT IDENTITY NOT NULL,
		SerialNumber nvarchar(100),
		DateAdded date,
		CONSTRAINT PK_EntriesTable PRIMARY KEY(EntriesId)
	);
ELSE
	PRINT 'The table already exists!'
GO

TRUNCATE TABLE EntriesTable;
GO

CREATE PROCEDURE usp_EntryTablePopulating
AS
	DECLARE @serialNumberStart nvarchar(100), @dateAddedStart date, @start int, @end int;
	SET @serialNumberStart = 'ABCDEF-0'
	SET @dateAddedStart = CONVERT(datetime, '01-01-1900', 102);
	SET @start = 1;
	SET @end = 10000000;

	WHILE @start <= @end
		BEGIN
			INSERT INTO EntriesTable (SerialNumber, DateAdded)
			VALUES (@serialNumberStart, @dateAddedStart)
			SET @start = @start + 1;
			SET @serialNumberStart = SUBSTRING(@serialNumberStart, 0, CHARINDEX('-', @serialNumberStart) + 1);
			SET @serialNumberStart = @serialNumberStart + CAST(@start AS nvarchar(MAX));
			SET @dateAddedStart = DATEADD(day, 1, @dateAddedStart)
		END
GO

SELECT COUNT(EntriesID) AS [Rows] FROM EntriesTable;
GO

SELECT EntriesId, SerialNumber, DateAdded
FROM EntriesTable
WHERE DateAdded BETWEEN '1900.01.01' AND '9000.01.01';
GO

/* Problem 2.	Add an index to speed-up the search by date 
Your task is to add an index to speed-up the search by date. Test the search speed (after cleaning the cache). */

DBCC FREEPROCCACHE
DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
GO

CREATE INDEX IDX_EntriesTable_DateAdded
ON EntriesTable(EntriesId, SerialNumber, DateAdded);
GO

SP_CONFIGURE 'show advanced options', 1
RECONFIGURE
GO

SP_CONFIGURE 'optimize for ad hoc workloads', 0
RECONFIGURE
GO

SELECT EntriesId, SerialNumber, DateAdded
FROM EntriesTable
WHERE DateAdded BETWEEN '1900.01.01' AND '9000.01.01';
GO

--DROP INDEX EntriesTable.IDX_EntriesTable_DateAdded;
--GO