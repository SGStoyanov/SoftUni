namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Models;

    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
            var db = new StudentSystemDbContext();
            
        }
    }
}