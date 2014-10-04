/* Problem 2.	Custom LINQ Extension Methods
Create your own LINQ extension methods:
•	public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate) { … } – works just like Where(predicate) but filters the non-matching items from the collection.
•	public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count) { … } – repeats the collection count times.
•	public static IEnumerable<string> WhereEndsWith<string>(this IEnumerable<string> collection, IEnumerable<string> suffixes) { … } – filters all items from the collection that ends with some of the specified suffixes. */

using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.CustomLINQExtensionMethods
{
    public static class CustomLinqExtMeths
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(item => !predicate(item));
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            for (int i = 0; i < count; i++)
            {
                foreach (var item in collection)
                {
                    yield return item;
                }

            }
        }

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection,
            IEnumerable<string> suffixes)
        {
            foreach (var word in collection)
            {
                foreach (var suffix in suffixes)
                {
                    if (word.Trim().EndsWith(suffix))
                    {
                        yield return word;
                    }
                }
            }
        }
    }

    class CustomLinqExtMethsTester
    {
        static void Main()
        {
            
            var list = new List<string>(new[] {"How", "am", "I", "gonna", "do", "it???"});
            var result = list.WhereNot(x => x.Equals("gonna"));

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var list2 = new List<string>(new[] {"Done", "Not", "Whatever"});
            var result2 = list2.Repeat(5);
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var words = new List<string>(new[] {"Shalalal", "labuba", "Lalal", "Door", "Enter", "Cosmic", "Romidor"});
            var suffixes = new List<string>(new[] {"lal", "or"});
            var result3 = words.WhereEndsWith(suffixes);

            foreach (var match in result3)
            {
                Console.WriteLine(match);
            }
        }
    }
}