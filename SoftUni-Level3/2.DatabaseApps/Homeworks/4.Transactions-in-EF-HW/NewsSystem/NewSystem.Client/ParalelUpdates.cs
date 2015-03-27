namespace NewSystem.Client
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using NewsSystem.Data;
    using NewsSystem.Data.Migrations;

    public class ParalelUpdates
    {
        public static void MakeParalelUpdate()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDbContext, Configuration>());
            var context = new NewsDbContext();
            var firstNews = context.News.FirstOrDefault();

            Console.WriteLine("First news current content: " + firstNews.Content);
            Console.WriteLine("Enter the new text: ");

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var newText = Console.ReadLine();
                    firstNews.Content = newText;
                    context.SaveChanges();
                    transaction.Commit();

                    Console.WriteLine("Update successful");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Conflict occured! \nThe transcation has been rolled back!");
                    Console.WriteLine(ex.Message);
                    MakeParalelUpdate();
                }
            }
        }
    }
}