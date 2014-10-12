using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Customer
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string lastName;
        private string middleName;
        private string id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;

        protected Customer(string firstName, string middleName, string lastName, string id, string permanentAddress, 
                        string mobilePhone, string email, CustomerType type, params Payment[] payments)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Type = type;
            this.Payments = payments.ToList();
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("FirstName", "The first name can't be null!");
                }
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("MiddleName", "The middle name can't be null!");
                }
                this.middleName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("LastName", "The last name can't be null!");
                }
                this.lastName = value;
            }
        }

        public string Id
        {
            get { return this.id; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Id", "The Id can't be null!");
                }
                this.id = value;
            }
        }

        public string PermanentAddress
        {
            get { return this.permanentAddress; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("PermanentAddress", "The permanent address can't be null!");
                }
                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get { return this.mobilePhone; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("MobilePhone", "The mobile phone can't be null!");
                }
                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email", "The email can't be null!");
                }
                this.email = value;
            }
        }

        public CustomerType Type { get; set; }

        public IList<Payment> Payments { get; set; }

        public override string ToString()
        {
            string paymentString = "";

            if (Payments != null)
            {
                paymentString = this.Payments.Aggregate(paymentString, (current, payment) => current + (payment));
            }

            return string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}", this.firstName, this.middleName, 
                                 this.lastName, this.id, this.permanentAddress, this.mobilePhone, this.email,
                                 this.Type, paymentString);
        }

        public override bool Equals(object param)
        {
            Customer customer = param as Customer;

            if (customer == null)
            {
                return false;
            }

            if (!Object.Equals(this.firstName, customer.firstName) || !Object.Equals(this.middleName,
                customer.middleName) || !Object.Equals(this.lastName, customer.lastName))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ MiddleName.GetHashCode() ^ LastName.GetHashCode();
        }

        public static bool operator == (Customer customer1, Customer customer2)
        {
            return Customer.Equals(customer1, customer2);
        }

        public static bool operator != (Customer customer1, Customer customer2)
        {
            return !(Customer.Equals(customer1, customer2));
        }

        public object Clone()
        {
            Payment[] currentPayments = new Payment[this.Payments.Count];
            for (int counter = 0; counter < this.Payments.Count; counter++)
            {
                currentPayments[counter] = this.Payments[counter];
            }

            return new Customer(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.Id,
                this.PermanentAddress,
                this.MobilePhone,
                this.Email,
                this.Type,
                currentPayments);
        }

        public int CompareTo(Customer other)
        {
            string fullName = "" + FirstName + MiddleName + LastName;
            string otherFullName = "" + other.FirstName + other.MiddleName + other.LastName;
            int result = fullName.CompareTo(otherFullName);

            if (result == 0)
            {
                result = this.Id.CompareTo(other.Id);
            }

            return result;
        }

    }
}