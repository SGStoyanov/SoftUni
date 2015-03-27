namespace NewsSystem.Data
{
    using System.Data.Entity;

    using NewsSystem.Data.Migrations;
    using NewsSystem.Models;

    public class NewsDbContext : DbContext, INewsDbContext
    {
        public NewsDbContext()
            : base("NewsDb")
        {
        }

        public IDbSet<News> News { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}