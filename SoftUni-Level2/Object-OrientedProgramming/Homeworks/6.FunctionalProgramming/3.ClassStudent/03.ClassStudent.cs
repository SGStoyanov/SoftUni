/* Problem 3.	Class Student
Create a class Student with properties FirstName, LastName, Age, FacultyNumber, Phone, Email, Marks (IList<int>), GroupNumber. Create a List<Student> with sample students. These students will be used for the next few tasks. */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    public class Student
    {
        // Declaring fields
        private string firstName;
        private string lastName;
        private int age;
        private int facultyNumber;
        private string phone;
        private string email;
        private IList<int> marks;
        private int groupNumber;

        // Declaring properties
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentNullException(value);
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentNullException(value);
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new ArgumentNullException(value.ToString());
                }
                this.age = value;
            }
        }

        public int FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new ArgumentNullException(value.ToString());
                }
                this.facultyNumber = value;
            }
        }

        public string Phone
        {
            get { return this.phone; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value.Length <= 4)
                {
                    throw new ArgumentNullException(value.ToString());
                }
                this.phone = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length <= 5 || !value.Contains('@') || !value.Contains('.'))
                {
                    throw new ArgumentNullException(value);
                }
                this.email = value;
            }
        }

        public IList<int> Marks
        {
            get { return this.marks; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException(value.ToString());
                }
                this.marks = value;
            }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new ArgumentNullException(value.ToString());
                }
                this.groupNumber = value;
            }
        }
        // Constructor with FirstName, LastName, Age, FacultyNumber, Phone, Email, Marks (IList<int>), GroupNumber
        public Student(string firstName, string lastName, int age, int facultyNumber, string phone, string email, IList<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public override string ToString()
        {
            return string.Format("First Name: {0}\nLast Name: {1}\nAge: {2}\nFaculty Number: {3}\nPhone: {4}\nEmail: {5}\nMarks: {6}\nGroup Number: {7}", this.firstName, this.lastName, this.age, this.facultyNumber, this.phone, this.email, string.Join(", ", marks.ToArray()), this.groupNumber);
        }
    }
}