// Implementing and testing Problem 3 - Class Student

using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    public class ClassStudentTester
    {
        public static void Main()
        {
            var ivanov = new Student("Leshper", "Ivanov", 25, 384389, "0899000123", "leshperivanov@gmail.com", new List<int>(new[] { 3, 4, 5, 5 }), 2);
            var georgiev = new Student("Georgi", "Georgiev", 26, 384390, "+3592493293", "georgigeorgiev@yahoo.com", new List<int>(new[] { 6, 6, 6, 5 }), 4);
            var rozmarinov = new Student("Bosilek", "Rozmarinov", 20, 384450, "+359888333333", "bosilek.r@abv.bg", new List<int>(new[] { 2, 3, 3, 2, 4 }), 4);
            var marinova = new Student("Petia", "Marinova", 19, 381214, "+359888999999", "p.marinova@gmail.com", new List<int>(new[] { 6, 5, 6 }), 5);
            var stoyanov = new Student("Stoyan", "Stoyanov", 24, 384414, "+359888444444", "s.stoyanov@mail.bg", new List<int>(new[] { 5, 4, 6, 4 }), 3);
            var petrov = new Student("Leonid", "Petrov", 27, 384452, "02456222", "leonidpetrov@hotmail.com", new List<int>(new[] { 2, 2, 3 }), 5);
            var jones = new Student("Tom", "Jones", 28, 384453, "+44291222111", "tomjones123@mailer.com", new List<int>(new[] { 5, 5, 4, 6, 5 }), 6);
            var li = new Student("Jet", "Li", 51, 384454, "+12399343434", "jetli@chinamail.ch", new List<int>(new int[] { 4, 4, 5, 6 }), 2);

            var students = new List<Student> { ivanov, georgiev, rozmarinov, marinova, stoyanov, petrov, jones, li };

            // Testing the solution of Problem 3
            //foreach (var student in students)
            //{
            //    Console.WriteLine(student);
            //    Console.WriteLine("----------------------------");
            //}

            // Problem 4 - Print all students from group number 2. Use a LINQ query. Order the students by FirstName.
            Console.WriteLine("*************************************");
            Console.WriteLine("Problem 4 - Students by Group (2)");
            Console.WriteLine("*************************************\n");

            var studentsFromGroup =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            foreach (var student in studentsFromGroup)
            {
                Console.WriteLine(student + "\n-----------------------------\n");
            }

            /* Problem 5.	Students by First and Last Name
            Print all students whose first name is before their last name alphabetically. Use a LINQ query. */
            Console.WriteLine("*************************************");
            Console.WriteLine("Problem 5 - Students by First and Last Name");
            Console.WriteLine("*************************************\n");

            var studentsFirstBeforeLastName =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            foreach (var student in studentsFirstBeforeLastName)
            {
                Console.WriteLine(student + "\n-----------------------------\n");
            }

            /* Problem 6.	Students by Age
              Write a LINQ query that finds the first name and last name of all students with age between 18 and 24. 
              The query should return only the first name, last name and age. */

            Console.WriteLine("*************************************");
            Console.WriteLine("Problem 6 - Students by Age(18 - 24)");
            Console.WriteLine("*************************************\n");

            var studentsByAge =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select new {FirstName = student.FirstName, LastName = student.LastName, Age = student.Age};

            foreach (var student in studentsByAge)
            {
                Console.WriteLine("First Name: {0}\nLast Name: {1}\nAge: {2}\n-----------------------------\n", student.FirstName, student.LastName, student.Age);
            }

            /* Problem 7.	Sort Students
              Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first 
              name and last name in descending order. Rewrite the same with LINQ query syntax. */

            Console.WriteLine("*************************************");
            Console.WriteLine("Problem 7 - Sort Students");
            Console.WriteLine("*************************************\n");

            var sortedStudentsWithLINQ = students.OrderByDescending(s => s.FirstName).ThenByDescending(l => l.LastName);

            var sortedStudents =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;
                

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student + "\n-----------------------------\n");
            }

            /* Problem 8.	Filter Students by Email Domain
             Print all students that have email @abv.bg. Use LINQ. */

            Console.WriteLine("*************************************");
            Console.WriteLine("Problem 8 - Filter Students by Email Domain");
            Console.WriteLine("*************************************\n");

            var filteredStudentsByEmail = students.Where(e => e.Email.EndsWith("@abv.bg"));

            foreach (var student in filteredStudentsByEmail)
            {
                Console.WriteLine(student + "\n-----------------------------\n");
            }

            /* Problem 9.	Filter Students by Phone
             Print all students with phones in Sofia (starting with 02 / +3592 / +359 2). Use LINQ. */

            Console.WriteLine("*************************************");
            Console.WriteLine("Problem 9 - Filter Students by Phone");
            Console.WriteLine("*************************************\n");

            var filterStudentsByPhone =
                students.Where(
                    p => (
                            p.Phone.StartsWith("02") || (p.Phone.StartsWith("+3592")) ||
                            p.Phone.StartsWith("+359 2"))
                         );

            foreach (var student in filterStudentsByPhone)
            {
                Console.WriteLine(student + "\n-----------------------------\n");
            }

            /* Problem 10.	Excellent Students
             Print all students that have at least one mark Excellent (6). Using LINQ first select them into a new 
             anonymous class that holds { FullName + Marks}. */

            Console.WriteLine("*************************************");
            Console.WriteLine("Problem 10 - Excellent Students");
            Console.WriteLine("*************************************\n");

            var excellentStudents =
                from student in students
                where student.Marks.Contains(6)
                select new {FullName = student.FirstName + " " + student.LastName, Marks = student.Marks};

            foreach (var student in excellentStudents)
            {
                Console.WriteLine("Full Name: {0}\nMarks: {1}\n-----------------------------\n", student.FullName, string.Join(", ", student.Marks));
            }

            /* Problem 11.	Weak Students
              Write a similar program to the previous one to extract the students with exactly two marks "2". 
              Use extension methods. */

            Console.WriteLine("*************************************");
            Console.WriteLine("Problem 11 - Weak Students");
            Console.WriteLine("*************************************\n");

            var weakStudents = students.Where(st => st.Marks.Count(m => m == 2) == 2);

            foreach (var student in weakStudents)
            {
                Console.WriteLine(student + "\n-----------------------------\n");
            }

            /* Problem 12.	Students Enrolled in 2014
             Extract and print the Marks of the students that enrolled in 2014 (the students from 2014 have 14 as their
             * 5-th and 6-th digit in the FacultyNumber). */

            Console.WriteLine("*************************************");
            Console.WriteLine("Problem 12 - Students Enrolled in 2014");
            Console.WriteLine("*************************************\n");

            var studentsEnrolled =
                from student in students
                where student.FacultyNumber%100 == 14
                select new {FullName = student.FirstName + " " + student.LastName, Marks = student.Marks};

            foreach (var student in studentsEnrolled)
            {
                Console.WriteLine("Full Name: " + student.FullName + "\nMarks: " + string.Join(", ", student.Marks) + "\n-----------------------------\n");
            }
        }
    }
}