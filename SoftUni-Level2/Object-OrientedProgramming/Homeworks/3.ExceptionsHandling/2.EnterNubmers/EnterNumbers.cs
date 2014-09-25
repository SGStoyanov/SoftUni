using System;

class EnterNumbers
{
    public static int ReadNumber(int start, int end)
    {
        string numAsStr = Console.ReadLine();
        int number = int.Parse(numAsStr);
        if (number < start || number > end)
        {
            throw new FormatException("The number must be in the range: [" + start + " .. " + end + "]");
        }
        return number;
    }

    static void Main()
    {
        int counter = 0;
        int start = 1;

        while (counter < 10)
        {
            try
            {
                int currentNum = ReadNumber(start, 100);

                if (currentNum > start)
                {
                    start = currentNum;
                }
                counter++;
            }
            catch (ArgumentException argex)
            {
                Console.WriteLine("{0} Repeat input!", argex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Repeat input!", ex.Message);
            }
        }
    }
}