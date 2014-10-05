using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    class HumanStudentWorkerTester
    {
        static void Main()
        {
            var testWorker = new Worker("Ivan", "Georgiev", 290.20, 8);
            var moneyPerHour = testWorker.MoneyPerHour();
            //Console.WriteLine(moneyPerHour);

            // Testing Student
            var albenova = new Student("Anna", "Albenova", 11111);
            var dimitrova = new Student("Petya", "Dimitrova", 11112);
            var denkova = new Student("Denica", "Denkova", 11113);
            var marks = new Student("Jennifer", "Marks", 11114);
            var unugugu = new Student("Ogonogo", "Unugugu", 11123);
            var kim = new Student("Yao", "Kim", 12311);
            var james = new Student("Dennis", "James", 12317);
            var heat = new Student("Phil", "Heat", 12316);
            var green = new Student("Kai", "Green", 12319);
            var coleman = new Student("Ronnie", "Coleman", 12318);

            var students = new List<Student>() { albenova, dimitrova, denkova, marks, unugugu, kim, james, heat, 
                                                 green, coleman };

            //Console.WriteLine("Students, unsorted:\n");
            //foreach (var student in students)
            //{
            //    Console.WriteLine("-----------------------\nFirst Name: {0}\nLast Name: {1}\nFaculty Number: {2}" +
            //                      "\n-----------------------\n", 
            //                      student.FirstName, student.LastName, student.FacultyNumber);
            //}

            var sortedStudents =
                from student in students
                orderby student.FacultyNumber
                select student;

            //Console.WriteLine("Students, sorted by Faculty Number:\n");
            //foreach (var sortedStudent in sortedStudents)
            //{
            //    Console.WriteLine("-----------------------\nFirst Name: {0}\nLast Name: {1}\nFaculty Number: {2}" +
            //                      "\n-----------------------\n",
            //                      sortedStudent.FirstName, sortedStudent.LastName, sortedStudent.FacultyNumber);
            //}

            // Testing Worker

            var worker1 = new Worker("Georgi", "Georgiev", 220.99, 8);
            var worker2 = new Worker("Alfonso", "Gomez", 120.99, 7);
            var worker3 = new Worker("Lui", "Fines", 323.50, 8);
            var worker4 = new Worker("Romul", "Remov", 420.50, 8);
            var worker5 = new Worker("Rosen", "Gacov", 330.99, 8);
            var worker6 = new Worker("Kosym", "Kosymchov", 122.99, 6);
            var worker7 = new Worker("Bliznak", "Bliznakov", 186.90, 12);
            var worker8 = new Worker("Petar", "Tudjarov", 125.00, 8);
            var worker9 = new Worker("Pope", "Popov", 170.00, 8);
            var worker10 = new Worker("Martin", "Georgiev", 150.00, 8);

            var workers = new List<Worker>()
            {
                worker1,
                worker2,
                worker3,
                worker4,
                worker5,
                worker6,
                worker7,
                worker8,
                worker9,
                worker10
            };

            var sortedWorkers = workers.OrderByDescending(p => p.MoneyPerHour());

            //Console.WriteLine("Workers sorted by payment per hour in descending order:\n");
            //foreach (var sortedWorker in sortedWorkers)
            //{
            //    Console.WriteLine("-----------------------\nFirst Name: {0}\nLast Name: {1}\nWeek Salary: {2}" +
            //                      "\nWork Hours per Day: {3}\nMoney per Hour: {4}" +
            //                      "\n-----------------------\n",
            //                      sortedWorker.FirstName, sortedWorker.LastName, 
            //                      sortedWorker.WeekSalary, sortedWorker.WorkHoursPerDay, 
            //                      sortedWorker.MoneyPerHour());
            //}

            var humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);
            var sortedHumans = humans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName);

            Console.WriteLine("Sorted humans:\n");
            foreach (var sortedHuman in sortedHumans)
            {
                Console.WriteLine("First Name: {0}\nLast Name: {1}\n", sortedHuman.FirstName, sortedHuman.LastName);
            }
        }
    }
}