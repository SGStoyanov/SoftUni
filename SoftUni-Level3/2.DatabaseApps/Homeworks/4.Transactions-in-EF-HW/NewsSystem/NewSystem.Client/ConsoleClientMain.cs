namespace NewSystem.Client
{
    using System.Data.Entity;

    using NewsSystem.Data;
    using NewsSystem.Data.Migrations;

    public class ConsoleClientMain
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDbContext, Configuration>());
            var database = new NewsDbContext();

            // Problem 2. Concurrent Updates (Console App)
            ParalelUpdates.MakeParalelUpdate();
        }
    }
}
