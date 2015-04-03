namespace DistanceCalculator.Client
{
    using System;
    using System.Net;

    public class ClientStart
    {
        public static void Main()
        {
            using (var client = new WebClient())
            {
                var query = client.UploadString(
                    "http://localhost:41925/CalcDistance?startPoint=30&endPoint=5",
                    "POST",
                    string.Empty);
                Console.WriteLine(query);
            }
        }
    }
}