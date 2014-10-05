using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    public class Student : Human
    {
        private int facultyNumber;

        public Student(string firstName, string lastName, int facultyNumber)
            : base(firstName, lastName)
        {
            this.facultyNumber = facultyNumber;
        }

        public int FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value <= 0)
                {
                    throw new ArgumentNullException("Faculty number", "The faculty number can not be null or negative!");
                }
                this.facultyNumber = value;
            }
        }
    }
}