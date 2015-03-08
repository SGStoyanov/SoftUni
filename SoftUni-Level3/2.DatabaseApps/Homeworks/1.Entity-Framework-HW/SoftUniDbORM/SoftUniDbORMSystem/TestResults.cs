namespace SoftUniDbORMSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TestResults
    {
        public static void Main()
        {
            // Testing Problem 2
            //EmployeeDao.GetEmployees();
            //EmployeeDao.UpdateEmployeesSalary(43, 15800);
            //EmployeeDao.DeleteEmployee(109);
            //EmployeeDao.InsertEmployee("Stoyan", "Stoyanov", "Boss", 1, 6, DateTime.Now, 150000, null, 40);

            /* Problem 3.	Employees with Projects after 2002
            Your task is to write a method that finds all employees who have projects with start date in 2002 year. */

            //EmployeeDao.EmployeesWithProjectsInGivenYear(2002);

            /* Problem 4.	Native SQL Query
            Your task is to solve the previous task by using native SQL query and executing it through the DbContext. */

            //EmployeeDao.EmployeesWithProjectsInGivenYear("2002");

            /* Problem 5.	Employees by Department and Manager
                Your task is to write a method that finds all employees by specified department (name) and 
                manager (first name and last name). */

            //EmployeeDao.EmployeesByGivenDepartmentAndManager("Sales", "Brian", "Welcker");

            /* Problem 6.	Concurrent Database Changes with EF
                Your task is to try to open two different data contexts and to perform 
                concurrent changes on the same records in some database table. 
                What will happen at SaveChanges()? How to deal with it? */

            //EmployeeDao.UpdateTwoEmployeesSimulteniously(5, 50000, 5, 10000);

            /* Problem 7.	Employees with Corresponding Territories
                Your task is to create a class, which allows employees to access their corresponding 
                territories as property of the type EntitySet<T> by inheriting the Employee entity 
                class or by using a partial class. */
            // Added Project FunctionalityExtender

            /* Problem 8.	Insert a New Project
                Your task is to create a method that inserts a new project in the SoftUni database. 
                The project should contain several employees. */

            //var softuniDbContext = new SoftUniEntities();
            //var employeesList = softuniDbContext.Employees.Where(
            //    e => e.EmployeeID == 8 && e.EmployeeID == 57).ToList();

            //EmployeeDao.AddNewProjectWithEmployees(
            //    "Test Project",
            //    "Just a test project...",
            //    DateTime.Today,
            //    DateTime.Today.AddDays(10),
            //    employeesList);

            // Problem 9.	Call a Stored Procedure
            //Console.WriteLine(EmployeeDao.GetProjectsCountByEmployee("Peng", "Wu"));
        }
    }
}