using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SquareRoot
{
    static void Main()
    {
        try
        {
            Console.Write("Enter your number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Square root: " + Math.Sqrt(number));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid number", ex);
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}