using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDisperser
{
    class TestStringDisperser
    {
        static void Main()
        {
            var testObject1 = new StringDisperser("string1", "string2", "string3");
            var testObject2 = new StringDisperser("string1", "string2", "string3");

            if (testObject1 == testObject2)
            {
                Console.WriteLine("{0} == {1}", testObject1, testObject2);
                Console.WriteLine(testObject1.GetHashCode() + " " + testObject2.GetHashCode());
            } 
            else if (testObject1 != testObject2)
            {
                Console.WriteLine("{0} != {1}", testObject1, testObject2);
            }

            var clonedObject = testObject2.Clone();

            if (testObject2.CompareTo(clonedObject) == 0)
            {
                Console.WriteLine("{0} is comparable to {1}", testObject2, clonedObject);
            }

            if (testObject1.Equals(clonedObject))
            {
                Console.WriteLine("{0} is equal to {1}", testObject1, clonedObject);;
            }

            var stringDisperser = new StringDisperser("gosho", "pesho", "tanio");

            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }

            Console.WriteLine();
        }
    }
}