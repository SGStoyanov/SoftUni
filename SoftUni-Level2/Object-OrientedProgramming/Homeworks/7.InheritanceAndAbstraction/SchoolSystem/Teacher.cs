using System;
using System.Collections.Generic;

namespace SchoolSystem
{
    public class Teacher : People
    {
        private IList<Discipline> disciplines; 

        public Teacher(string name) 
            : base(name)
        {
            this.Disciplines = new List<Discipline>();
        }

        public Teacher(string name, List<Discipline> disciplines)
            : this(name)
        {
            this.Disciplines = disciplines;
        }

        public Teacher(string name, List<Discipline> disciplines, string detail)
            : this(name, disciplines)
        {
            this.Detail = detail;
        }

        public IList<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException("Disciplines", "Disciplines couldn't be empty or null");
                }
                this.disciplines = value;
            }
        }
    }
}