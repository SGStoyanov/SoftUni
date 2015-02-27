/* Problem 29.	Write a SQL to create table WorkHours to store work reports for each employee.
Each employee should have id, date, task, hours and comments. Don't forget to define identity, 
primary key and appropriate foreign key. */

USE SoftUni;
GO

CREATE TABLE WorkHours (
	WorkHoursId int IDENTITY NOT NULL PRIMARY KEY,
	[Date] date,
	Task nvarchar(200) NOT NULL,
	[Hours] float,
	Comment nvarchar(200),
	EmployeeId int FOREIGN KEY REFERENCES Employees(EmployeeId) NOT NULL
);
GO