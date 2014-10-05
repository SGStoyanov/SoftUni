using System;
using System.Collections.Generic;

namespace SchoolSystem
{
    public class SchoolSystemTester
    {
        public static void Main()
        {
            var stoyanov = new Student("Stoyanov", "54443AZ");
            var petrov = new Student("Petrov", "54444AZ", "no like");
            var mimi = new Student("Mimi", "55221RX", "very cute");

            var students = new List<Student> { stoyanov, petrov, mimi };
            

            var teachers = new List<Teacher> { new Teacher("Gadiov"), new Teacher("Ivanov"), new Teacher("Georgiev") };
            teachers[1].Detail = "The best teacher ever";

            foreach (var teacher in teachers)
            {
                Console.WriteLine("Teacher: " + teacher.Name);
            }

            foreach (var student in students)
            {
                Console.WriteLine("Student: " + student.Name + " - " + student.UniqueClassNum + " - " + student.Detail);
            }

            var history = new Discipline("History", new List<Student>() { stoyanov, petrov, mimi}, 25);
            var mechanics = new Discipline("Mechanics", new List<Student>() { mimi, petrov }, 53, "important discipline");

            var class19A = new SchoolClass("19A", students, teachers);

            var mySchool = new School(new List<SchoolClass>() { class19A });
        }
    }
}