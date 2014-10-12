using System;

namespace Customer
{
    public class GoldenCustomer : Customer
    {
        public GoldenCustomer(string firstName, string middleName, string lastName, string id, string permanentAddress, string mobilePhone, string email, CustomerType type, params Payment[] payments) : base(firstName, middleName, lastName, id, permanentAddress, mobilePhone, email, type, payments)
        {
        }
    }
}