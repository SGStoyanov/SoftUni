using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class AnimalsTester
    {
        static void Main()
        {
            var scooby = new Dog("Scooby", 2, 'm');
            var frogy = new Frog("Frogy", 0.5, 'm');
            var tommy = new Cat("Tommy", 1, 'm');
            var kitty = new Kitten("Kitty", 0.8, 'f');
            var speedy = new Tomcat("Speedy", 1.5, 'f');
            var spark = new Dog("Spark", 3, 'm');
            var carmit = new Frog("Carmit", 1, 'm');
            var jenny = new Kitten("Jenny", 1.2, 'f');

            var animals = new Animal[] { scooby, spark, frogy, tommy, kitty, speedy };
            var differentAnimals = new Animal[] { tommy, kitty, carmit, jenny };

            foreach (var animal in animals)
            {
                Console.Write(animal);
                animal.ProduceSound();
                Console.WriteLine();
            }

            var groupedAnimals =
                from anim in animals
                group anim by (anim is Cat) ? typeof (Cat) : anim.GetType()
                into g
                select new {GroupName = g.Key, AverageAge = g.ToList().Average(an => an.Age)};

            foreach (var animal in groupedAnimals)
            {
                Console.WriteLine("{0} - average age: {1:N2}", animal.GroupName.Name, animal.AverageAge);
            }
        }
    }
}