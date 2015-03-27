namespace NewsSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using NewsSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<NewsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            //this.ContextKey = "NewsSystem.Data.NewsDbContext";
        }

        protected override void Seed(NewsDbContext context)
        {
            //context.News.AddOrUpdate(
            //    n => n.Content,
            //    new News { Content = "Yes, I know" },
            //    new News { Content = "Varna is the best" },
            //    new News { Content = "The summer is comming" },
            //    new News { Content = "Say no to Russia" },
            //    new News { Content = "Do you love penguins?" },
            //    new News { Content = "������� ������, ������� ������" });

            //context.SaveChanges();
            //base.Seed(context);
        }
    }
}
