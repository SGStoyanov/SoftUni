/* Problem 1.	StringBuilder Extensions
Implement the following extension methods for the class StringBuilder:
•	Substring(int startIndex, int length) – returns a new String object, containing the elements in the given range. Throw an exception when the range is invalid.
•	RemoveText(string text) – removes all occurrences of the specified text (case-insensitive) from the StringBuilder. The method should not create a new StringBuilder, but should modify the existing one and return it as a result.
•	AppendAll<T>(IEnumerable<T> items) – appends the string representations of all items from the specified collection. Use ToString() to convert from T to string.
Write a program to demonstrate that your new extension methods work correctly. */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FunctionalProgramming
{

    public static class SBExtensions
    {
        public static string Substring(this StringBuilder sb, int startIndex, int length)
        {
            if (startIndex + length > sb.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            char[] tempArray = new char[length];
            sb.CopyTo(startIndex, tempArray, 0, length);
            string tempStr = new string(tempArray);
            return tempStr;
        }

        public static StringBuilder RemoveText(this StringBuilder sb, string text)
        {
            if ( string.IsNullOrEmpty(text) || string.IsNullOrEmpty(sb.ToString()) )
            {
                throw new ArgumentNullException();
            }
            string tempStr = sb.ToString();
            string replacedStr = Regex.Replace(tempStr, text, "", RegexOptions.IgnoreCase);
            sb.Clear();
            sb.Append(replacedStr);
            return sb;
        }

        public static StringBuilder AppendAll<T>(this StringBuilder sb, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                sb.Append(item);
            }
            return sb;
        }
    }

    class StringBuilderExtensionsTester
    {
        static void Main()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Something Good Really Good good");
            string temp = stringBuilder.Substring(9, 5);
            Console.WriteLine(temp);

            stringBuilder.RemoveText("good");
            Console.WriteLine(stringBuilder);

            var testAppendSb = new StringBuilder();
            testAppendSb.AppendAll(new List<string>() {"Hi, ", "I ", "am ", "a new ", "StringBuilder"});
            Console.WriteLine(testAppendSb);
        }
    }
}