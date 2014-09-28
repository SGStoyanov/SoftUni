/* Problem 3.	Student Class
Write a class Student that holds name and age. Add an event PropertyChanged that should fire whenever a property of Student is changed, displaying a message in the format Property changed: <property> (from <old value> to <new value>). Create a custom PropertyChangedEventArgs class to keep the property name, old value and new value. */

using System;

namespace _3.StudentClass
{
    class StudentTester
    {
        static void Main()
        {
            var firstStudent = new Student("Stoyan", 27);
            var secondStudent = new Student("Robert", 35);

            firstStudent.PropertyChanged += (sender, eventArgs) => 
                Console.WriteLine("Property changed: {0} (from {1} to {2})",
                eventArgs.Property, eventArgs.OldValue, eventArgs.NewValue);

            secondStudent.PropertyChanged += (sender, eventArgs) =>
                Console.WriteLine("Property changed: {0} (from {1} to {2})",
                eventArgs.Property, eventArgs.OldValue, eventArgs.NewValue);

            firstStudent.Name = "Hristo";
            firstStudent.Age = 15;

            secondStudent.Name = "De Niro";
            secondStudent.Age = 66;
        }
    }
}