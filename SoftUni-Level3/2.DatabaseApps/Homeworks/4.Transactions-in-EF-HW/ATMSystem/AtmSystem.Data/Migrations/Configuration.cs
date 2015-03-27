namespace AtmSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using ATMSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<AtmDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AtmDbContext context)
        {
            //var cardAccount = new CardAccount { CardNumber = "1234567890", CardPin = "2911", CardCash = 1500m };
            //var cardAccount2 = new CardAccount { CardNumber = "1234567891", CardPin = "1484", CardCash = 5900m };
            //var cardAccount3 = new CardAccount { CardNumber = "1234567895", CardPin = "8954", CardCash = 200m };

            //context.CardAccounts.AddOrUpdate(cardAccount, cardAccount2, cardAccount3);

            //context.SaveChanges();
        }
    }
}