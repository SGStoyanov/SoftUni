/* Problem 1.	Interest Calculator
Create a delegate CalculateInterest (or use Func<…>) with parameters sum of money, interest and years that calculates the interest according to the method it points to. The result should be rounded to 4 places after the decimal point.
•	Create a method GetSimpleInterest(sum, interest, years). The interest should be calculated by the formula A = sum * (1 + interest * years).
•	Create a method GetCompoundInterest(sum, interest, years).  The interest should be calculated by the formula A = sum * (1 + interest / n)year * n, where n is the number of times per year the interest is compounded. Assume n is always 12.
Create a class InterestCalculator that takes in its constructor money, interest, years and interest calculation delegate
*/

using System;

namespace InterestCalculatorNS
{
    public class InterestCalculator
    {
        // Fields
        public delegate decimal CalculateInterest(decimal moneySum, decimal interest, int years);

        private decimal sum;
        private decimal interest;
        private int years;
        private CalculateInterest type;

        public decimal Sum
        {
            get { return this.sum; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new ArgumentException("Wrong sum!");
                }
                this.sum = value;
            }
        }

        // Properties
        public int Years
        {
            get { return this.years; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new ArgumentException("Wrong years!");
                }
                this.years = value;
            }
        }

        public decimal Interest
        {
            get { return this.interest; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The interest couldn't be a negative number!");
                }
                this.interest = value;
            }
        }

        // Main Constructor
        public InterestCalculator(decimal sum, decimal interest, int years, CalculateInterest type)
        {
            this.Sum = sum;
            this.Interest = interest;
            this.Years = years;           
            this.type = type;
        }

        public override string ToString()
        {
            return string.Format("{0:F4}", this.type(this.sum, this.interest, this.years));
        }
    }
}