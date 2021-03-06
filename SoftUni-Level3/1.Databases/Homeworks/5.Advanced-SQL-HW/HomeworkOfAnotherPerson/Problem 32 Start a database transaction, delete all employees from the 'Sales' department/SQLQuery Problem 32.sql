--Problem 32.	
--Start a database transaction, delete all employees from the 'Sales' department along with all 
--dependent records from the other tables. At the end rollback the transaction.
ALTER TABLE employees
DROP CONSTRAINT FK_Employees_Departments;
ALTER TABLE employees
ADD CONSTRAINT FK_Employees_Departments FOREIGN KEY (ManagerID)
REFERENCES employees (EmployeeId) ON DELETE CASCADE;

ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees;
ALTER TABLE Departments
ADD CONSTRAINT FK_Departments_Employees FOREIGN KEY (DepartmentID)
REFERENCES Departments (DepartmentID) ON DELETE CASCADE

ALTER TABLE Departments
ADD CONSTRAINT FK_Departments_Employees FOREIGN KEY (ManagerID)
REFERENCES Employees (EmployeeID) ON DELETE CASCADE;
ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Employees
ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Employees FOREIGN KEY(ManagerId)
REFERENCES Employees(EmployeeID) ON DELETE CASCADE

BEGIN TRAN;
DELETE FROM employees
WHERE departmentID = (SELECT
		departmentId
	FROM departments
	WHERE Name = 'Sales');
ROLLBACK TRAN;
