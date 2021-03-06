--Problem 30.	
--Issue few SQL statements to insert, update and delete of some data in the table.

INSERT INTO WorkHours (EmployeeId, WorkDate, Task, WorkHours, Comments)
	VALUES (1, '2013-12-20', 'BGCoder Project: accept zip file', 6.5, 'Initial class structure created');
INSERT INTO WorkHours (EmployeeId, WorkDate, Task, WorkHours, Comments)
	VALUES (33, '2013-12-20', 'BGCoder Project: accept zip file', 6.5, 'Initial class structure created');
INSERT INTO WorkHours (EmployeeId, WorkDate, Task, WorkHours, Comments)
	VALUES (220, '2013-12-20', 'BGCoder Project: accept zip file', 3.33, 'Initial class structure created');
INSERT INTO WorkHours (EmployeeId, WorkDate, Task, WorkHours, Comments)
	VALUES (133, '2013-12-21', 'BGCoder Project: accept zip file', 2.67, 'Bug fixed');
INSERT INTO WorkHours (EmployeeId, WorkDate, Task, WorkHours, Comments)
	VALUES (55, '2013-12-21', 'BGCoder Project: accept zip file', 1.08, 'some class implementation');
INSERT INTO WorkHours (EmployeeId, WorkDate, Task, WorkHours, Comments)
	VALUES (46, '2013-12-22', 'BGCoder Project: accept zip file', 2.33, 'Initial class structure created');

UPDATE WorkHours
SET WorkDate = '2013-12-21'
WHERE WorkHours.EmployeeId = 1;

DELETE FROM WorkHours
WHERE EmployeeId = 33;