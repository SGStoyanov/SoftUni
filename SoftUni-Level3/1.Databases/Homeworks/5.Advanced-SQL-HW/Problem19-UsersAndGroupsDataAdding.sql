/* Problem 19.	Write SQL statements to insert several records in the Users and Groups tables. */

USE SoftUni;
GO

INSERT INTO Groups (Name)
VALUES ('PowerfulGroup'), ('WeakGroup'), ('JustGroup'), ('Admins'), ('Users'), ('PrintUsers');
GO

INSERT INTO Users (Username, [PassWord], FullName, LastLoginTime, GroupID)
VALUES ('User1', 'pass1', 'User Userov 1', '', 1),
	   ('User2', 'pass2', 'User Userov 2', '', 2),
	   ('User3', 'pass1', 'User Userov 3', '', 2),
	   ('User4', 'pass1', 'User Userov 4', '', 2),
	   ('User5', 'pass1', 'User Userov 5', '', 2);
GO

-- SELECT * FROM Groups;
-- SELECT * FROM Users;