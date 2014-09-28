using System;
using System.ComponentModel;

namespace _3.StudentClass
{
    public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs eventArgs);

    public class Student
    {
        private string name;
        private int age;
        private PropertyChangedEventArgs changedArgs;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.changedArgs = new PropertyChangedEventArgs("Name", this.Name, value); 
                this.name = value;
                this.OnPropertyChanged(this, changedArgs);
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0 || value > 150)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.changedArgs = new PropertyChangedEventArgs("Age", this.Age.ToString(), value.ToString());
                this.age = value;
                this.OnPropertyChanged(this, changedArgs);                
            }
        }

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs changedArgs)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, changedArgs);
            }
        }
    }
}