using System;
using System.Collections.Generic;

namespace SchoolSystem
{
    public class SchoolClass : IDetail
    {
        private static IList<string> uniqueIds;

        private string uniqueId;
        private IList<Teacher> teachers;
        private IList<Student> students;
        private string detail;

        static SchoolClass()
        {
            SchoolClass.uniqueIds = new List<string>();
        }

        public SchoolClass(string uniqueId, IList<Student> students, IList<Teacher> teachers)
        {
            this.UniqueId = uniqueId;
            this.Students = students;
            this.Teachers = teachers;
            SchoolClass.uniqueIds.Add(uniqueId);
        }

        public string UniqueId
        {
            get { return this.uniqueId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("UniqueId", "Unique IDs couldn't be null");
                }
                
                if (uniqueIds.Contains(value))
                {
                    throw new ArithmeticException("This Unique ID is already taken.");
                }
                this.uniqueId = value;
            }
        }

        public IList<Teacher> Teachers
        {
            get { return this.teachers; }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException("Teachers", "Teachers couldn't be null");
                }
                this.teachers = value;
            }
        }

        public IList<Student> Students
        {
            get { return this.students; }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException("Students", "Students couldn't be null");
                }
                this.students = value;
            }
        }

        public string Detail
        {
            get { return this.detail; }
            set { this.detail = value; }
        }
    }
}