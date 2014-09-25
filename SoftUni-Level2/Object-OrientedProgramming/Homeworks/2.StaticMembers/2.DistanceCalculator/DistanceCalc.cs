using System;

public static class DistanceCalculator
{
    public static double CalculateDistance(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        double deltaX = x1 - x2;
        double deltaY = y1 - y2;
        double deltaZ = z1 - z2;

        double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        distance = Math.Round(distance, 2);
        return distance;
    }
}
class Results
{
    static void Main()
    {
        double result = DistanceCalculator.CalculateDistance(1.5, 1.6, 1.1, 20.9, 2.23, 16);
        Console.WriteLine("Distance: " + result);
    }
}