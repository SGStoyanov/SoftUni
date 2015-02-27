-- Problem 30.	Issue few SQL statements to insert, update and delete of some data in the table.

USE SoftUni;
GO

INSERT WorkHours ([Date], Task, [Hours], Comment, EmployeeId)
VALUES ('02-02-2015', 'Working on something', 3.2, '', 1),
	   ('02-05-2015', 'Working on something', 5.6, '', 2),
	   ('02-06-2015', 'Working on something', 6, '', 3),
	   ('02-08-2015', 'Working on something', 1, '', 1),
	   ('02-06-2015', 'Working on something', 6, 'Not very important', 7);
GO

UPDATE WorkHours
SET Comment = 'Super duper important task!'
WHERE WorkHoursId = 2;
GO

DELETE WorkHours
WHERE WorkHoursId = 3 AND EmployeeId = 3;
GO