using System;

namespace SchoolSystem
{
    public abstract class People : IDetail
    {
        private string name;
        private string detail;

        protected People(string name)
        {
            this.name = name;
        }

        protected People(string name, string detail) : this(name)
        {
            this.Detail = detail;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Name couldn't be empty");
                }
                this.name = value;
            }
        }

        public string Detail
        {
            get { return this.detail; }
            set { this.detail = value; }
        }
    }
}