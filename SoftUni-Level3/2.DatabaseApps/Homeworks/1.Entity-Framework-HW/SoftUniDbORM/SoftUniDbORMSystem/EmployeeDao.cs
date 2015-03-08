namespace SoftUniDbORMSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EmployeeDao
    {
        private static readonly SoftUniEntities SoftUniContext = new SoftUniEntities();

        public static void GetEmployees()
        {
            IQueryable<Employee> employees =
                from e in SoftUniContext.Employees
                select e;

            Logger.PrintQueries(employees);

            Console.WriteLine("The result is being generated...");
            Console.WriteLine();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        public static void InsertEmployee(
            string firstName,
            string lastName,
            string jobTitle,
            int departmentId,
            int managerId,
            DateTime hireDate,
            decimal salary,
            string middleName = null,
            int addressId = 0)
        {
            var newEmployee = new Employee
                                  {
                                      FirstName = firstName,
                                      MiddleName = middleName,
                                      LastName = lastName,
                                      JobTitle = jobTitle,
                                      DepartmentID = departmentId,
                                      ManagerID = managerId,
                                      HireDate = hireDate,
                                      Salary = salary,
                                      AddressID = addressId
                                  };
            SoftUniContext.Employees.Add(newEmployee);
            SoftUniContext.SaveChanges();
            Console.WriteLine("Employee added.");
        }

        public static void UpdateEmployeesSalary(int employeeId, decimal newSalary)
        {
            var employee = GetEmployeeById(SoftUniContext, employeeId);
            var oldSalary = employee.Salary;
            employee.Salary = newSalary;
            SoftUniContext.SaveChanges();
            var result = string.Format(
                "Salary updated.\nOld Salary: {0:C} \nNew Salary: {1:C}", oldSalary, employee.Salary);
            Console.WriteLine(result);
        }

        public static void DeleteEmployee(int employeeId)
        {
            foreach (var e in SoftUniContext.Employees.Where(i => i.EmployeeID == employeeId))
            {
                SoftUniContext.Employees.Remove(e);
            }
            
            SoftUniContext.SaveChanges();
            Console.WriteLine("Employee with Id " + employeeId + " has been deleted!");
        }

        //Problem 3
        public static void EmployeesWithProjectsInGivenYear(int givenYear)
        {
            var employees = from e in SoftUniContext.Employees
                        join ep in SoftUniContext.EmployeesProjects on e.EmployeeID equals ep.EmployeeID
                        join p in SoftUniContext.Projects on ep.ProjectID equals p.ProjectID
                        where p.StartDate.Year == givenYear
                        select new { e.FirstName, e.LastName, ProjectStartDate = p.StartDate };

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
            }
        }

        // Problem 4
        public static void EmployeesWithProjectsInGivenYear(string givenYear)
        {
            var sqlQuery =
                "SELECT e.EmployeeID, e.FirstName, e.MiddleName, e.LastName, e.JobTitle, "
                + "e.DepartmentID, e.ManagerID, e.HireDate, e.Salary, e.AddressID, p.StartDate "
                + "FROM Employees e "
                + "INNER JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID "
                + "INNER JOIN Projects p ON ep.ProjectID = p.ProjectID "
                + "WHERE YEAR(p.StartDate) = {0}";
            IEnumerable<Employee> employeesWithStartedProjectsInYear =
                SoftUniContext.Database.SqlQuery<Employee>(sqlQuery, givenYear);

            foreach (var employee in employeesWithStartedProjectsInYear)
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
            }
        }

        // Problem 5
        public static void EmployeesByGivenDepartmentAndManager(
            string departmentName,
            string managerFirstName,
            string managerLastName)
        {
            var employees = (from e in SoftUniContext.Employees
                            join d in SoftUniContext.Departments on e.DepartmentID equals d.DepartmentID
                            join m in SoftUniContext.Employees on e.EmployeeID equals m.ManagerID
                            where string.Equals(d.Name, departmentName)
                            select new { e.FirstName, e.LastName }).Distinct();
            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
            }
        }

        // Problem 6
        public static void UpdateTwoEmployeesSimulteniously(
            int firstEmployeeId,
            decimal firstSalary,
            int secondEmployeeId,
            decimal secondSalary)
        {
            var firstEmployee = GetEmployeeById(SoftUniContext, firstEmployeeId);
            firstEmployee.Salary = firstSalary;
            var softUniContext2 = new SoftUniEntities();
            var secondEmployee = GetEmployeeById(softUniContext2, secondEmployeeId);
            secondEmployee.Salary = secondSalary;
            SoftUniContext.SaveChanges();
            softUniContext2.SaveChanges();
        }

        private static Employee GetEmployeeById(SoftUniEntities entity, int employeeId)
        {
            var employeeById = entity.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            return employeeById;
        }
    }
}