-- Problem 19.	Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO [SoftUni].[dbo].[Users] (Username, Password, FullName, LastLoginTime, GroupId)
	VALUES ('peshkata', '123456', 'Pesho', GETDATE(), 3)
INSERT INTO [SoftUni].[dbo].[Users] (Username, Password, FullName, LastLoginTime, GroupId)
	VALUES ('marcheto', 'marcheto123', 'Maria', GETDATE(), 2)
INSERT INTO [SoftUni].[dbo].[Users] (Username, Password, FullName, LastLoginTime, GroupId)
	VALUES ('valka', '12345', 'Vasil', GETDATE(), 1)