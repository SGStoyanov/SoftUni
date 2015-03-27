namespace AtmSystem.Client
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;

    using AtmSystem.Data;
    using AtmSystem.Models;

    public class TransactionalAtmWithdrawal
    {
        public static void TransactWithdraw(string cardNumber, string cardPin, decimal withdrawMoney)
        {
            var db = new AtmDbContext();

            const string ConnectionString = 
                "data source=.\\SQLEXPRESS;initial catalog=ATM;integrated"
                + " security=True;MultipleActiveResultSets=True;App=EntityFramework";

            using (var con = new SqlConnection { ConnectionString = ConnectionString })
            {
                con.Open();

                using (var explicitTrans = con.BeginTransaction(System.Data.IsolationLevel.RepeatableRead))
                {
                    try
                    {
                        var searchCardAccount = db.CardAccounts.FirstOrDefault(n => n.CardNumber.Equals(cardNumber));

                        if (searchCardAccount != null && searchCardAccount.CardNumber.Equals(cardNumber))
                        {
                            if (cardPin.Equals(searchCardAccount.CardPin))
                            {
                                if (searchCardAccount.CardCash > withdrawMoney)
                                {
                                    searchCardAccount.CardCash = searchCardAccount.CardCash - withdrawMoney;

                                    var transHistoryInsert = 
                                        new TransactionHistory
                                        {
                                            CardNumber = searchCardAccount.CardNumber,
                                            TranscationDate = DateTime.Now,
                                            Amount = searchCardAccount.CardCash
                                        };

                                    db.TransactionHistory.AddOrUpdate(transHistoryInsert);

                                    db.SaveChanges();
                                    explicitTrans.Commit();
                                    Console.WriteLine("Money withdrawn");
                                }
                                else
                                {
                                    ThrowArgumentException(
                                        withdrawMoney.ToString(CultureInfo.InvariantCulture),
                                        "Not enough money in the account");
                                }
                            }
                            else
                            {
                                ThrowArgumentException(cardPin, "Wrong pin");
                            }
                        }
                        else
                        {
                            ThrowArgumentException(cardNumber, "Wrong Card Number");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Withdraw not possible, try again");
                        Console.WriteLine(ex.Message);
                        explicitTrans.Rollback();
                    }
                }
            }
        }

        private static void ThrowArgumentException(string variable, string message)
        {
            throw new ArgumentException(message, variable);
        }
    }
}