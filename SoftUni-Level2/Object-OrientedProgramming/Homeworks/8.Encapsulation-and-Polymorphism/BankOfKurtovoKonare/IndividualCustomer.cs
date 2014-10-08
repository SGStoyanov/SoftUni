namespace BankSystem
{
    public class IndividualCustomer : Customer
    {
        public IndividualCustomer(string name)
            : base(name)
        {
            this.Name = name;
        }
    }
}