namespace BankSystem
{
    using System;
    using System.Collections.Generic;

    public class TestBankSystem
    {
        public static void Main()
        {
            ICustomer gosho = new IndividualCustomer("Georgi Georgiev");
            ICustomer myCompany = new CompanyCustomer("My Company Ltd.");

            IAccount mortAccInd = new MortgageAccount(gosho, 924m, 2.4m);
            IAccount mortgageAccComp = new MortgageAccount(myCompany, 888m, 7.4m);

            IAccount loanAccInd = new LoanAccount(gosho, 2048m, 4.5m);
            IAccount loanAccComp = new LoanAccount(myCompany, 512m, 6.0m);

            IAccount depositAccIndBig = new DepositAccount(gosho, 888, 6.6m);
            IAccount depositAccIndSmall = new DepositAccount(gosho, 1111m, 7.9m);
            IAccount depositAccComp = new DepositAccount(myCompany, 50326m, 4.9m);

            List<IAccount> accounts = new List<IAccount>()
            {
                mortAccInd,
                mortgageAccComp,
                loanAccInd,
                loanAccComp,
                depositAccIndBig,
                depositAccIndSmall,
                depositAccComp
            };

            foreach (var acc in accounts)
            {
                Console.WriteLine(
                    "{5} {0,-15}: {1:N2}, {2:N2}, {3:N2}, {4:N2}",
                    acc.GetType().Name,
                    acc.CalculateRate(2),
                    acc.CalculateRate(3),
                    acc.CalculateRate(10),
                    acc.CalculateRate(13),
                    acc.Customer.GetType().Name);
            }
        }
    }
}