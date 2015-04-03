namespace DistanceCalculatorSoap.Client
{
    using System;

    using DistanceCalculatorSoap.Client.ServiceReferenceDistanceCalculator;

    public class ClientStart
    {
        public static void Main()
        {
            var calc = new DistanceCalculatorClient();
            var result = calc.CalculateDistance(
                new Point() { X = 5, Y = 10 }, 
                new Point() { X = 10, Y = 15 });

            Console.WriteLine(result);
        }
    }
}