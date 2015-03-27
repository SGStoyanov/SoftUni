namespace AtmSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using ATMSystem.Models;

    using AtmSystem.Models;

    public class AtmDbContext : DbContext
    {
        // Your context has been configured to use a 'ATM' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AtmSystem.Data.ATM' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ATM' 
        // connection string in the application configuration file.
        public AtmDbContext()
            : base("name=ATM")
        {
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionHistory> TransactionHistory { get; set; } 
    }
}