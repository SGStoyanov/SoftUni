using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmSystem.Client
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    using AtmSystem.Data;
    using AtmSystem.Data.Migrations;

    using ATMSystem.Models;

    public class AtmSystemMain
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmDbContext, Configuration>());
            var context = new AtmDbContext();

            // Problems 1, 2
            //var cardAccount = new CardAccount { CardNumber = "1234567896", CardPin = "3932", CardCash = 100000m };
            //context.CardAccounts.AddOrUpdate(cardAccount);

            // Problems 4, 5, 6
            TransactionalAtmWithdrawal.TransactWithdraw("1234567896", "3932", 1000m);

            context.SaveChanges();
        }
    }
}