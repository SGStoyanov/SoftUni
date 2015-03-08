namespace SoftUniDbORMSystem
{
    using System;
    using System.Collections.Generic;

    public static class ProjectsDao
    {
        private static readonly SoftUniEntities SoftUniContext = new SoftUniEntities();

        // Problem 8
        public static void AddNewProjectWithEmployees(
            string name,
            string description,
            DateTime startDate,
            DateTime endDate,
            ICollection<Employee> employees)
        {
            var newProject = new Project
                                 {
                                     Name = name,
                                     Description = description,
                                     StartDate = startDate,
                                     EndDate = endDate,
                                     Employees = employees
                                 };
            SoftUniContext.Projects.Add(newProject);

            SoftUniContext.SaveChanges();
            Console.WriteLine("Project added.");
        }

        // Problem 9
        public static int GetProjectsCountByEmployee(string firstName, string lastName)
        {
            var projectsCount = SoftUniContext.usp_TotalProjectsForEmployee(firstName, lastName).FirstOrDefault();
            return projectsCount.Value;
        }
    }
}