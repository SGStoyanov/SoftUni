using System;

namespace InterestCalculatorNS
{
    class InterestCalculatorTester
    {

        // Methods
        public static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
        {
            decimal result = sum * (1 + (interest / 100) * years);
            return result;
        }

        public static decimal GetCompoundInterest(decimal sum, decimal interest, int years)
        {
            decimal result = sum * (decimal)Math.Pow((double)(1 + (interest / 100) / 12), (years * 12));
            return result;
        }

        static void Main()
        {
            var simpleInterest = new InterestCalculator(500m, 5.6m, 10, GetCompoundInterest);
            Console.WriteLine(simpleInterest);

            var compoundInterest = new InterestCalculator(2500m, 7.2m, 15, GetSimpleInterest);
            Console.WriteLine(compoundInterest);
        }

    }
}