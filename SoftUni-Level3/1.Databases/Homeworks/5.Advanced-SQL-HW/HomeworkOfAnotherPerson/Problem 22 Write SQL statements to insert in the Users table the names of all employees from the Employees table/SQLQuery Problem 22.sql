-- Problem 22.	Write SQL statements to insert in the Users table the names of all employees from the Employees table.

BEGIN TRAN
ALTER TABLE Users NOCHECK CONSTRAINT "CHK_Users_Password_Length";
INSERT INTO [SoftUni].[dbo].[Users] (Username, Password, FullName, GroupId)

	SELECT
		CONVERT(NVARCHAR(50), SUBSTRING(LOWER(FirstName), 0, 2) + '' + LOWER(LastName) + ISNULL(MiddleName, '')) AS Username,
		CONVERT(NVARCHAR(50), SUBSTRING(LOWER(FirstName), 1, 1) + '' + LOWER(LastName)) AS [Password],
		CONVERT(NVARCHAR(50), FirstName + ' ' + LastName) AS [FullName],
		2
	FROM [SoftUni].[dbo].[Employees]
ALTER TABLE Users CHECK CONSTRAINT "CHK_Users_Password_Length";
ROLLBACK TRAN
