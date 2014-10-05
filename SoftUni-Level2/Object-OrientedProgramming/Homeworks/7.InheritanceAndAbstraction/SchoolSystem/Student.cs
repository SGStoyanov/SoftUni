using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolSystem
{
    public class Student : People
    {
        private static IList<string> takenClassNums;
        private string uniqueClassNum;

        static Student()
        {
            Student.takenClassNums = new List<string>();
        }

        public Student(string name, string uniqueClassNum) : base(name)
        {
            this.uniqueClassNum = uniqueClassNum;
            Student.takenClassNums.Add(uniqueClassNum);
        }

        public Student(string name, string uniqueClassNum, string detail) : this(name, uniqueClassNum)
        {
            this.Detail = detail;
        }

        public string UniqueClassNum
        {
            get { return this.uniqueClassNum; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Unique class number of student couldn't be empty!");
                }
                else if (takenClassNums.Contains(value))
                {
                    throw new ArgumentException("The assigned unique class number is already used. Try another one.");
                }
                this.uniqueClassNum = value;
            }
        }
    }
}