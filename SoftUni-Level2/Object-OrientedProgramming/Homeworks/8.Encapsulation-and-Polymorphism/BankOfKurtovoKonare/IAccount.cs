namespace BankSystem
{
    public interface IAccount
    {
        ICustomer Customer { get; set; }

        decimal Balance { get; }

        decimal MonthlyInterestRate { get; }

        decimal CalculateRate(double months);
    }
}