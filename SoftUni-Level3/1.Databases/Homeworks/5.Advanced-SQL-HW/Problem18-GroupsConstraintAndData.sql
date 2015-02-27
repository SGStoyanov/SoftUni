/* Problem 18.	Write a SQL statement to add a column GroupID to the table Users.
Fill some data in this new column and as well in the Groups table. 
Write a SQL statement to add a foreign key constraint between tables Users and Groups tables. */

USE SoftUni;
GO

ALTER TABLE Users
	ADD GroupID int;
GO

ALTER TABLE Users
	ADD FOREIGN KEY (GroupID)
	REFERENCES Groups(Id);
GO

INSERT Groups VALUES('First');
GO

INSERT Groups VALUES('Second');
GO

INSERT Groups VALUES('Third');
GO

UPDATE Users SET GroupID = 1;
GO

INSERT INTO Users (GroupID)
VALUES (2);
GO

INSERT INTO Users(Username, [PassWord], FullName, LastLoginTime, GroupID)
VALUES ('Admin', 'BigSecret', 'The Admin here', '02-15-2015', 2);
GO

INSERT INTO Users(Username, [PassWord], FullName, LastLoginTime, GroupID)
VALUES ('FriendlyUser', 'SmallSecret', 'Friendly User', '02-10-2015', 2);
GO

INSERT INTO Users(Username, [PassWord], FullName, LastLoginTime, GroupID)
VALUES ('hacker', 'ifItellYouIWillHaveToKillYou', 'Hacker Hackerov', '01-01-2015', 3);
GO

-- SELECT * FROM Users;
-- SELECT * FROM Groups;