/* Problem 2.	Fraction Calculator
Create a struct Fraction that holds the numerator and denominator of a fraction as fields. A fraction is the division of two rational numbers (e.g. 22 / 7, where 22 is the numerator and 7 is the denominator).
•	The struct constructor takes the numerator and denominator as arguments. They are integer numbers in the range [-9223372036854775808…9223372036854775807]. 
•	Validate the input through properties. The denominator cannot be 0. Throw proper exceptions with descriptive messages.
•	Overload the + and - operators to perform addition and subtraction on objects of type Fraction. The result should be a new Fraction.
•	Override ToString() to print the fraction in floating-point format. */

using System;

namespace OtherTypes
{

    struct Fraction
    {
        private long numerator;
        private long denominator;

        public long Numerator
        {
            get { return this.numerator; }
            set
            {
                try
                {
                    this.numerator = value;
                }
                catch (ArgumentException argex)
                {
                    Console.WriteLine("Bad numerator\n" + argex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Wrong data\n" + ex.Message);
                }
            }
        }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("The denominator couldn't be zero!");
                }
                this.denominator = value;
            }
        }

        // Main contstructor
        public Fraction(long num, long denum) : this()
        {
            this.Numerator = num;
            this.Denominator = denum;
        }

        public static Fraction operator +(Fraction frac1, Fraction frac2)
        {
            long num = frac1.numerator * frac2.denominator + frac2.numerator * frac1.denominator;
            long denum = frac1.denominator * frac2.denominator;
            return new Fraction(num, denum);
        }
        public static Fraction operator -(Fraction frac1, Fraction frac2)
        {
            long num = frac1.numerator * frac2.denominator - frac2.numerator * frac1.denominator;
            long denum = frac1.denominator * frac2.denominator;
            return new Fraction(num, denum);
        }

        public override string ToString()
        {
            double result = (double)this.numerator/(double)this.denominator;
            return result.ToString();
        }
    }

    class FractionCalculator
    {
        static void Main()
        {
            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4);
            Fraction result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);
        }
    }
}