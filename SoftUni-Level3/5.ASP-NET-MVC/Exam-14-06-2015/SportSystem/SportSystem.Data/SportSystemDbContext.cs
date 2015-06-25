namespace SportSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;

    using SportSystem.Data.Migrations;
    using SportSystem.Models;

    public class SportSystemDbContext : IdentityDbContext<User>, ISportSystemDbContext
    {
        public SportSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SportSystemDbContext, Configuration>());
        }

        public static SportSystemDbContext Create()
        {
            return new SportSystemDbContext();
        }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}